using QuanLyQuanCafe.DataBase;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAO
{
    public class EmployeeDAO
    {
        private static EmployeeDAO instance;
        public static EmployeeDAO Instance
        {
            get { if (instance == null) instance = new EmployeeDAO(); return instance; }
            private set { instance = value; }
        }

        private EmployeeDAO() { }

        public string GetMaxEmployeeId()
        {
            DatabaseConnection db = new DatabaseConnection();
            string query = "SELECT ISNULL(MAX(MaNV), 'NV0') FROM NhanVien";
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        var result = command.ExecuteScalar();
                        return result?.ToString() ?? "NV0";
                    }
                }
            }
            catch { return "NV0"; }
        }

        private List<EmployeeDTO> ExecuteEmployeeQuery(string storedProcedureName, SqlParameter[] parameters = null)
        {
            List<EmployeeDTO> employeeList = new List<EmployeeDTO>();
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(storedProcedureName, conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        if (parameters != null) command.Parameters.AddRange(parameters);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string maNV = reader["MaNV"].ToString();
                                string hoTen = reader["HoTen"].ToString();
                                string sdt = reader["SDT"].ToString();
                                DateTime ngayVaoLam = Convert.ToDateTime(reader["NgayVaoLam"]);
                                float luong = Convert.ToSingle(reader["Luong"]);
                                string diaChi = reader["DiaChi"].ToString();
                                string chucNang = reader["TenChucNang"].ToString();

                                employeeList.Add(new EmployeeDTO(maNV, hoTen, sdt, luong, diaChi, ngayVaoLam, chucNang));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Lỗi khi lấy danh sách nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return employeeList;
        }

        public bool AddEmployeeAndAccount(string maNV, string hoTen, string sdt, DateTime ngayVaoLam, float luong, string diaChi, string chucNang, ref string newMaNV)
        {
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_AddEmployeeAndAccount", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        SqlParameter maNVParam = new SqlParameter("@MaNV", SqlDbType.NVarChar, 100) { Direction = ParameterDirection.InputOutput, Value = maNV ?? (object)DBNull.Value };
                        command.Parameters.Add(maNVParam);
                        command.Parameters.AddWithValue("@HoTen", hoTen);
                        command.Parameters.AddWithValue("@SDT", sdt);
                        command.Parameters.AddWithValue("@NgayVaoLam", ngayVaoLam);
                        command.Parameters.AddWithValue("@Luong", luong);
                        command.Parameters.AddWithValue("@DiaChi", diaChi);
                        command.Parameters.AddWithValue("@ChucNang", chucNang);

                        SqlParameter returnParameter = new SqlParameter { Direction = ParameterDirection.ReturnValue };
                        command.Parameters.Add(returnParameter);

                        command.ExecuteNonQuery();
                        newMaNV = maNVParam.Value?.ToString();
                        int rowsAffected = (int)returnParameter.Value;
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi thêm nhân viên: {ex.Message}", "Lỗi Cơ Sở Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public bool UpdateEmployee(string maNV, string hoTen, string sdt, DateTime ngayVaoLam, float luong, string diaChi, string chucNang)
        {
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_UpdateEmployee", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaNV", maNV);
                        command.Parameters.AddWithValue("@HoTen", hoTen);
                        command.Parameters.AddWithValue("@SDT", sdt);
                        command.Parameters.AddWithValue("@NgayVaoLam", ngayVaoLam);
                        command.Parameters.AddWithValue("@Luong", luong);
                        command.Parameters.AddWithValue("@DiaChi", diaChi);
                        command.Parameters.AddWithValue("@ChucNang", chucNang);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            throw new Exception("Không có hàng nào được cập nhật. Vui lòng kiểm tra Mã NV.");
                        }
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                throw new Exception($"Lỗi cập nhật nhân viên: {ex.Message}");
            }
            catch (Exception ex)
            {
                throw new Exception($"Lỗi cập nhật nhân viên: {ex.Message}");
            }
        }

        public bool DeleteEmployeeAndAccount(string maNV)
        {
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_DeleteEmployeeAndAccount", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaNV", maNV);

                        SqlParameter returnParameter = new SqlParameter { Direction = ParameterDirection.ReturnValue };
                        command.Parameters.Add(returnParameter);

                        command.ExecuteNonQuery();
                        int rowsAffected = (int)returnParameter.Value;
                        return rowsAffected > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Lỗi xóa nhân viên: {ex.Message}", "Lỗi Cơ Sở Dữ Liệu", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public List<EmployeeDTO> GetEmployeeList()
        {
            return ExecuteEmployeeQuery("usp_GetEmployeeList");
        }

        public List<EmployeeDTO> SearchEmployees(string keyword)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", keyword)
            };
            return ExecuteEmployeeQuery("usp_SearchEmployee", parameters);
        }
    }
}