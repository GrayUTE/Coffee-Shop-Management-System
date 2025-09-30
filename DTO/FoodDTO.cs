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

        public FoodDTO(int maSP, string tenSp, string loaiSp, float donGia)
        {
            MaSP = maSP;
            TenSp = tenSp;
            LoaiSp = loaiSp;
            DonGia = donGia;
        }

    }
}
