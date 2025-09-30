using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DataBase
{
    public class DatabaseConnection
    {
        private readonly string connectionString =
            "Server=GrayDE;Database=QuanLyQuanCafe;Trusted_Connection=True;";

        public SqlConnection GetConnection()
        {
            return new SqlConnection(connectionString);
        }

        public bool TestConnection()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    MessageBox.Show("Kết nối thành công!", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    string query = "SELECT * FROM NhanVien";
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        // Tạo Command
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            try
                            {
                                connection.Open();
                                // Thực thi và lấy dữ liệu
                                SqlDataReader reader = command.ExecuteReader();

                                // Đọc từng dòng dữ liệu
                                while (reader.Read())
                                {
                                    
                                    Console.WriteLine(reader["MaNV"].ToString());
                                    
                                }
                                reader.Close();
                            }
                            catch (SqlException ex)
                            {
                                // Xử lý lỗi SQL, ví dụ: ghi log
                                Console.WriteLine("Lỗi SQL: " + ex.Message);
                                // Bạn có thể chọn re-throw hoặc trả về danh sách trống
                                // throw; 
                            }
                            catch (Exception ex)
                            {
                                // Xử lý các lỗi khác
                                Console.WriteLine("Lỗi chung: " + ex.Message);
                            }
                        }
                    }
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Lỗi kết nối: " + ex.Message, "Thông báo lỗi",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return false;
                }
            }
        }
    }
}

