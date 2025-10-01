using QuanLyQuanCafe.DataBase;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace QuanLyQuanCafe.DAO
{
    public class CustomerDAO
    {
        private static CustomerDAO instance;
        public static CustomerDAO Instance
        {
            get { if (instance == null) instance = new CustomerDAO(); return instance; }
            private set { instance = value; }
        }

        private CustomerDAO() { }

        public int GetMaxCustomerId()
        {
            DatabaseConnection db = new DatabaseConnection();
            string query = "SELECT ISNULL(MAX(MaKH), 0) FROM KhachHang";
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand(query, conn))
                    {
                        var result = command.ExecuteScalar();
                        return result != DBNull.Value ? Convert.ToInt32(result) : 0;
                    }
                }
            }
            catch (Exception)
            {
                return 0;
            }
        }

        private List<CustomerDTO> ExecuteCustomerQuery(string storedProcedureName, SqlParameter[] parameters, out string errorMessage)
        {
            List<CustomerDTO> customerList = new List<CustomerDTO>();
            errorMessage = string.Empty;
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
                                int maKhachHang = Convert.ToInt32(reader["MaKH"]);
                                string hoTen = reader["HoTen"].ToString();
                                string soDienThoai = reader["SDT"].ToString();
                                int diemTichLuy = Convert.ToInt32(reader["DiemTichLuy"]);

                                customerList.Add(new CustomerDTO(maKhachHang, hoTen, soDienThoai, diemTichLuy));
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                errorMessage = $"Lỗi khi lấy danh sách khách hàng: {ex.Message}";
            }
            return customerList;
        }

        public bool AddCustomer(string hoTen, string soDienThoai, int diemTichLuy, out int newMaKhachHang, out string errorMessage)
        {
            newMaKhachHang = 0;
            errorMessage = string.Empty;
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_AddCustomer", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@HoTen", hoTen);
                        command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        command.Parameters.AddWithValue("@DiemTichLuy", diemTichLuy);
                        SqlParameter maKHParam = new SqlParameter("@MaKhachHang", SqlDbType.Int) { Direction = ParameterDirection.Output };
                        command.Parameters.Add(maKHParam);

                        command.ExecuteNonQuery();
                        newMaKhachHang = (int)maKHParam.Value;
                        return newMaKhachHang > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
                return false;
            }
        }

        public bool UpdateCustomer(int maKhachHang, string hoTen, string soDienThoai, int diemTichLuy, out string errorMessage)
        {
            errorMessage = string.Empty;
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_UpdateCustomer", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                        command.Parameters.AddWithValue("@HoTen", hoTen);
                        command.Parameters.AddWithValue("@SoDienThoai", soDienThoai);
                        command.Parameters.AddWithValue("@DiemTichLuy", diemTichLuy);

                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected == 0)
                        {
                            errorMessage = "Không tìm thấy khách hàng để cập nhật.";
                            return false;
                        }
                        return true;
                    }
                }
            }
            catch (SqlException ex)
            {
                errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
                return false;
            }
        }

        public bool DeleteCustomer(int maKhachHang, out string errorMessage)
        {
            errorMessage = string.Empty;
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_DeleteCustomer", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaKhachHang", maKhachHang);
                        SqlParameter returnParameter = new SqlParameter("@ReturnValue", SqlDbType.Int) { Direction = ParameterDirection.ReturnValue };
                        command.Parameters.Add(returnParameter);

                        command.ExecuteNonQuery();
                        int returnValue = (int)returnParameter.Value;
                        if (returnValue == -1)
                        {
                            errorMessage = "Không thể xóa khách hàng do có hóa đơn liên quan.";
                            return false;
                        }
                        return returnValue > 0;
                    }
                }
            }
            catch (SqlException ex)
            {
                errorMessage = $"Lỗi cơ sở dữ liệu: {ex.Message}";
                return false;
            }
        }

        public List<CustomerDTO> GetCustomerList()
        {
            string errorMessage;
            return ExecuteCustomerQuery("usp_GetCustomerList", null, out errorMessage);
        }

        public List<CustomerDTO> SearchCustomers(string keyword)
        {
            SqlParameter[] parameters = new SqlParameter[]
            {
                new SqlParameter("@Keyword", keyword)
            };
            string errorMessage;
            return ExecuteCustomerQuery("usp_SearchCustomer", parameters, out errorMessage);
        }
    }
}