
using QuanLyQuanCafe.DataBase;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace QuanLyQuanCafe.DAO
{
    public class FoodDAO
    {
        private static FoodDAO instance;
        public static FoodDAO Instance
        {
            get { if (instance == null) instance = new FoodDAO(); return instance; }
            private set { instance = value; }
        }

        private FoodDAO() { }

        public List<FoodDTO> GetFoodList()
        {
            List<FoodDTO> foodList = new List<FoodDTO>();
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_getFoodList", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["MaSP"]);
                                string name = reader["TenSP"].ToString();
                                string category = reader["LoaiSP"].ToString();
                                float price = Convert.ToSingle(reader["DonGia"]);
                                FoodDTO food = new FoodDTO(id, name, category, price);
                                foodList.Add(food);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong GetFoodList: {ex.Message}");
                throw;
            }
            return foodList;
        }

        public int AddFood(string ten, string loai, float gia)
        {
            if (string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(loai) || gia < 0)
            {
                Console.WriteLine("Tham số đầu vào không hợp lệ cho AddFood");
                return -1;
            }

            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_addFood", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@TenSP", ten);
                        command.Parameters.AddWithValue("@LoaiSP", loai);
                        command.Parameters.AddWithValue("@DonGia", gia);

                        object result = command.ExecuteScalar();
                        return result != null ? Convert.ToInt32(result) : -1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong AddFood: {ex.Message}");
                return -1;
            }
        }



        public bool UpdateFood(int maSP, string ten, string loai, float gia)
        {
            if (maSP <= 0 || string.IsNullOrWhiteSpace(ten) || string.IsNullOrWhiteSpace(loai) || gia < 0)
            {
                Console.WriteLine("Tham số đầu vào không hợp lệ cho UpdateFood");
                return false;
            }

            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_updateFood", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaSP", maSP);
                        command.Parameters.AddWithValue("@TenSP", ten);
                        command.Parameters.AddWithValue("@LoaiSP", loai);
                        command.Parameters.AddWithValue("@DonGia", gia);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong UpdateFood: {ex.Message}");
                return false;
            }
        }

        public bool DeleteFood(int maSP)
        {
            if (maSP <= 0)
            {
                Console.WriteLine("MaSP không hợp lệ cho DeleteFood");
                return false;
            }

            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_deleteFood", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@MaSP", maSP);
                        command.ExecuteNonQuery();
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong DeleteFood: {ex.Message}");
                return false;
            }
        }

        public List<FoodDTO> FilterFood(string loai)
        {
            List<FoodDTO> foodList = new List<FoodDTO>();
            DatabaseConnection db = new DatabaseConnection();

            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_filterFood", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@FilterType", loai ?? "Tất cả");
                        Console.WriteLine($"Gọi usp_filterFood với FilterType: '{loai}'");
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                int id = Convert.ToInt32(reader["MaSP"]);
                                string name = reader["TenSP"].ToString();
                                string category = reader["LoaiSP"].ToString();
                                float price = Convert.ToSingle(reader["DonGia"]);
                                FoodDTO food = new FoodDTO(id, name, category, price);
                                foodList.Add(food);
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                string errorDetails = $"Lỗi SQL trong FilterFood: {ex.Message}\n" +
                                      $"Error Number: {ex.Number}\n" +
                                      $"Procedure: {ex.Procedure}\n" +
                                      $"Line: {ex.LineNumber}";
                Console.WriteLine(errorDetails);
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return foodList;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khác trong FilterFood: {ex.Message}");
                MessageBox.Show($"Lỗi khi lọc dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return foodList;
            }

            return foodList;
        }
        public int GetLastFoodId()
        {
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("SELECT ISNULL(MAX(MaSP), 0) FROM SanPham", conn))
                    {
                        var result = command.ExecuteScalar();
                        return Convert.ToInt32(result);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi trong GetLastFoodId: {ex.Message}");
                return 0;
            }
        }

        public List<FoodDTO> SearchFood(string keyword)
        {
            List<FoodDTO> foodList = new List<FoodDTO>();
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // GỌI STORED PROCEDURE
                    using (SqlCommand command = new SqlCommand("usp_searchFood", conn))
                    {
                        command.CommandType = CommandType.StoredProcedure;

                        // Thêm tham số cho Stored Procedure
                        command.Parameters.AddWithValue("@Keyword", keyword ?? string.Empty);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                // Đảm bảo các tên cột khớp với DTO và DB
                                int id = Convert.ToInt32(reader["MaSP"]);
                                string name = reader["TenSP"].ToString();
                                string category = reader["LoaiSP"].ToString();
                                float price = Convert.ToSingle(reader["DonGia"]);
                                foodList.Add(new FoodDTO(id, name, category, price));
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"Lỗi SQL trong SearchFood: {ex.Message}");
                MessageBox.Show($"Lỗi khi tìm kiếm dữ liệu: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khác trong SearchFood: {ex.Message}");
            }

            return foodList;
        }
    }
}
