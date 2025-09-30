using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuanLyQuanCafe.BUS
{
    public class FoodBUS
    {
        private static FoodBUS instance;
        public static FoodBUS Instance
        {
            get { if (instance == null) instance = new FoodBUS(); return instance; }
            private set { instance = value; }
        }
        private FoodBUS() { }

        public List<FoodDTO> GetFoodList()
        {
            return FoodDAO.Instance.GetFoodList();
        }
    }
}