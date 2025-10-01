using System;

namespace QuanLyQuanCafe.DTO
{
    public class CustomerDTO
    {
        public int MaKhachHang { get; set; }
        public string HoTen { get; set; }
        public string SoDienThoai { get; set; }
        public int DiemTichLuy { get; set; }

        public CustomerDTO(int maKhachHang, string hoTen, string soDienThoai, int diemTichLuy)
        {
            MaKhachHang = maKhachHang;
            HoTen = hoTen;
            SoDienThoai = soDienThoai;
            DiemTichLuy = diemTichLuy;
        }
    }
}