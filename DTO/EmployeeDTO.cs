using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.DTO
{
    public class EmployeeDTO
    {
        public string MaNV { get; set; }
        public string HoTen { get; set; }
        public string SDT { get; set; }
        public float Luong { get; set; }
        public string DiaChi { get; set; }
        public DateTime NgayVaoLam { get; set; }
        public string AccountID { get; set; } // Khớp với TaiKhoan.ID
        public string TenChucNang { get; set; } // Tên vai trò (Staff, Admin...)

        // Constructor đầy đủ
        public EmployeeDTO(string maNV, string hoTen, string sdt, float luong, string diaChi, DateTime ngayVaoLam, string chucNang)
        {
            MaNV = maNV;
            HoTen = hoTen;
            SDT = sdt;
            Luong = luong;
            DiaChi = diaChi;
            NgayVaoLam = ngayVaoLam;
            AccountID = maNV;
            TenChucNang = chucNang;
        }
    }
}