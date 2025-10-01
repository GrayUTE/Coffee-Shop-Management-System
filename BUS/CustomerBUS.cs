using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace QuanLyQuanCafe.BUS
{
    public class CustomerBUS
    {
        private static CustomerBUS instance;

        public static CustomerBUS Instance
        {
            get { if (instance == null) instance = new CustomerBUS(); return instance; }
            private set { instance = value; }
        }

        private CustomerBUS() { }

        public bool AddCustomer(string hoTen, string soDienThoai, int diemTichLuy, out int newMaKhachHang, out string errorMessage)
        {
            newMaKhachHang = 0;
            errorMessage = string.Empty;

            // Xác thực đầu vào
            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(soDienThoai))
            {
                errorMessage = "Họ tên và số điện thoại không được để trống.";
                return false;
            }

            //if (!Regex.IsMatch(soDienThoai, @"^\d{10}$"))
            //{
            //    errorMessage = "Số điện thoại phải gồm đúng 10 chữ số.";
            //    return false;
            //}

            if (diemTichLuy < 0)
            {
                errorMessage = "Điểm tích lũy phải là số không âm.";
                return false;
            }

            return CustomerDAO.Instance.AddCustomer(hoTen, soDienThoai, diemTichLuy, out newMaKhachHang, out errorMessage);
        }

        public bool UpdateCustomer(int maKhachHang, string hoTen, string soDienThoai, int diemTichLuy, out string errorMessage)
        {
            errorMessage = string.Empty;

            // Xác thực đầu vào
            if (maKhachHang <= 0)
            {
                errorMessage = "Mã khách hàng không hợp lệ.";
                return false;
            }

            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(soDienThoai))
            {
                errorMessage = "Họ tên và số điện thoại không được để trống.";
                return false;
            }

            if (diemTichLuy < 0)
            {
                errorMessage = "Điểm tích lũy phải là số không âm.";
                return false;
            }

            return CustomerDAO.Instance.UpdateCustomer(maKhachHang, hoTen, soDienThoai, diemTichLuy, out errorMessage);
        }

        public bool DeleteCustomer(int maKhachHang, out string errorMessage)
        {
            errorMessage = string.Empty;

            if (maKhachHang <= 0)
            {
                errorMessage = "Mã khách hàng không hợp lệ.";
                return false;
            }

            return CustomerDAO.Instance.DeleteCustomer(maKhachHang, out errorMessage);
        }

        public List<CustomerDTO> GetCustomerList()
        {
            return CustomerDAO.Instance.GetCustomerList();
        }

        public List<CustomerDTO> SearchCustomers(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetCustomerList();
            }
            return CustomerDAO.Instance.SearchCustomers(keyword);
        }

        public int GetMaxCustomerId()
        {
            return CustomerDAO.Instance.GetMaxCustomerId();
        }
    }
}