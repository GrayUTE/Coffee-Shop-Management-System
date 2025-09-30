using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class FoodDTO
    {
        public int MaSP { get; set; }
        public string TenSp { get; set; }
        public string LoaiSp { get; set; }
        public float DonGia { get; set; }
        public int SoLuong { get; set; } // BỔ SUNG: Thuộc tính Số Lượng

        // SỬA ĐỔI: Constructor mới có SoLuong
        public FoodDTO(int maSP, string tenSp, string loaiSp, float donGia, int soLuong)
        {
            MaSP = maSP;
            TenSp = tenSp;
            LoaiSp = loaiSp;
            DonGia = donGia;
            SoLuong = soLuong; // GÁN GIÁ TRỊ MỚI
        }

        // Giữ Constructor cũ để tránh lỗi ở các phần chưa cập nhật
        public FoodDTO(int maSP, string tenSp, string loaiSp, float donGia)
        {
            MaSP = maSP;
            TenSp = tenSp;
            LoaiSp = loaiSp;
            DonGia = donGia;
            SoLuong = 1; // Mặc định là 1 nếu không truyền vào
        }
    }
}