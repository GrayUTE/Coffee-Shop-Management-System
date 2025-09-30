using QuanLyQuanCafe.DataBase;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            int id = Convert.ToInt32(reader["MaSP"]);
                            string name = reader["TenSP"].ToString();
                            string category = reader["LoaiSP"].ToString();
                            int price = Convert.ToInt32(reader["DonGia"]);
                            FoodDTO food = new FoodDTO(id, name, category, price);
                            foodList.Add(food);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return foodList;
        }
    }
}