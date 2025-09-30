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
        private static int MaxFoodId; // Biến tĩnh để theo dõi MaxID

        public static FoodBUS Instance
        {
            get { if (instance == null) instance = new FoodBUS(); return instance; }
            private set { instance = value; }
        }

        private FoodBUS()
        {
            // Khởi tạo MaxFoodId từ cơ sở dữ liệu khi tạo instance
            MaxFoodId = InitializeMaxFoodId();
        }

        private int InitializeMaxFoodId()
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
                        int maxId = Convert.ToInt32(result);
                        Console.WriteLine($"InitializeMaxFoodId: MaxFoodId = {maxId}");
                        return maxId;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Lỗi khi khởi tạo MaxFoodId: {ex.Message}");
                return 0;
            }
        }

        public List<FoodDTO> GetFoodList()
        {
            return FoodDAO.Instance.GetFoodList();
        }

        // ĐÃ CẬP NHẬT: Thêm tham số soLuong và truyền vào FoodDAO
        public int AddFood(string ten, string loai, float gia, int soLuong)
        {
            int newId = FoodDAO.Instance.AddFood(ten, loai, gia, soLuong); // Truyền thêm soLuong
            if (newId > 0)
            {
                // Nếu là món mới (ID lớn hơn ID tối đa hiện tại), cập nhật MaxFoodId
                if (newId > MaxFoodId)
                {
                    MaxFoodId = newId;
                }
            }
            return newId;
        }

        // ĐÃ CẬP NHẬT: Thêm tham số soLuong và truyền vào FoodDAO
        public bool UpdateFood(int maSP, string ten, string loai, float gia, int soLuong)
        {
            return FoodDAO.Instance.UpdateFood(maSP, ten, loai, gia, soLuong); // Truyền thêm soLuong
        }

        public bool DeleteFood(int maSP)
        {
            bool success = FoodDAO.Instance.DeleteFood(maSP);
            if (success)
            {
                MaxFoodId = InitializeMaxFoodId(); // Cập nhật MaxFoodId sau khi xóa
                Console.WriteLine($"DeleteFood: MaxFoodId cập nhật thành {MaxFoodId}");
            }
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

        // ĐÃ BỔ SUNG: Phương thức SearchFood
        public List<FoodDTO> SearchFood(string keyword)
        {
            // Gọi phương thức SearchFood đã được thêm vào FoodDAO
            return FoodDAO.Instance.SearchFood(keyword);
        }

        public int GetMaxFoodId()
        {
            Console.WriteLine($"GetMaxFoodId: Trả về MaxFoodId = {MaxFoodId}");
            return MaxFoodId;
        }
    }
}