using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DataBase;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QuanLyQuanCafe.BUS
{
    public class FoodBUS
    {
        private static FoodBUS instance;
        // KHÔNG CÒN BIẾN TĨNH MaxFoodId

        public static FoodBUS Instance
        {
            get { if (instance == null) instance = new FoodBUS(); return instance; }
            private set { instance = value; }
        }

        //private FoodBUS()
        //{
        //    // Bỏ InitializeMaxFoodId()
        //}

        // HÀM QUAN TRỌNG: Luôn truy vấn DB để lấy MaSP lớn nhất hiện tại
        public int GetMaxFoodId()
        {
            DatabaseConnection db = new DatabaseConnection();
            try
            {
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    // Lấy MAX(MaSP) hiện tại từ DB. Nếu bảng trống, trả về 0.
                    using (SqlCommand command = new SqlCommand("SELECT ISNULL(MAX(MaSP), 0) FROM SanPham", conn))
                    {
                        var result = command.ExecuteScalar();
                        int maxId = Convert.ToInt32(result);
                        Console.WriteLine($"GetMaxFoodId (DB Query): Trả về MaxFoodId = {maxId}");
                        return maxId;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi lấy MaxFoodId từ DB: {ex.Message}");
                return 0;
            }
        }

        public List<FoodDTO> GetFoodList()
        {
            return FoodDAO.Instance.GetFoodList();
        }

        public int AddFood(string ten, string loai, float gia)
        {
            int newId = FoodDAO.Instance.AddFood(ten, loai, gia);
            // KHÔNG CẦN CẬP NHẬT BIẾN TĨNH
            return newId;
        }


        public bool UpdateFood(int maSP, string ten, string loai, float gia)
        {
            return FoodDAO.Instance.UpdateFood(maSP, ten, loai, gia);
        }

        public bool DeleteFood(int maSP)
        {
            bool success = FoodDAO.Instance.DeleteFood(maSP);
            // KHÔNG CẦN CẬP NHẬT BIẾN TĨNH
            return success;
        }

        public List<FoodDTO> FilterFood(string loai)
        {
            loai = loai?.Trim();
            if (loai != "Tất cả" && loai != "Đồ ăn" && loai != "Đồ uống")
            {
                Console.WriteLine($"Lọc theo '{loai}' không hợp lệ");
                return new List<FoodDTO>();
            }
            return FoodDAO.Instance.FilterFood(loai);
        }

        public List<FoodDTO> SearchFood(string keyword)
        {
            keyword = keyword?.Trim();
            if (string.IsNullOrEmpty(keyword))
            {
                // Nếu từ khóa rỗng, trả về toàn bộ danh sách
                return GetFoodList();
            }

            return FoodDAO.Instance.SearchFood(keyword);
        }
    }
}