using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuanLyQuanCafe.DataBase;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe.DAO
{
    public class AccountDAO
    {
        private static AccountDAO instance;
        public static AccountDAO Instance
        {
            get { if (instance == null) instance = new AccountDAO(); return instance; }
            private set { instance = value; }
        }
        private AccountDAO() { }

        public AccountDTO GetAccount(string userName, string passWord)
        {
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (SqlCommand command = new SqlCommand("usp_Login", conn))
                    {
                        command.CommandType = System.Data.CommandType.StoredProcedure;
                        command.Parameters.AddWithValue("@userName", userName);
                        command.Parameters.AddWithValue("@passWord", passWord);

                        SqlDataReader reader = command.ExecuteReader();
                        if (reader.Read())
                        {
                            string id = reader["ID"].ToString();
                            string role = reader["TenChucNang"].ToString();
                            return new AccountDTO(id, role);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            return null;
        }
    }
}