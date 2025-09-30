using QuanLyQuanCafe.DAO;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace QuanLyQuanCafe.BUS
{
    public class EmployeeBUS
    {
        private static EmployeeBUS instance;
        private static string MaxEmployeeId;

        public static EmployeeBUS Instance
        {
            get { if (instance == null) instance = new EmployeeBUS(); return instance; }
            private set { instance = value; }
        }

        private EmployeeBUS()
        {
            MaxEmployeeId = EmployeeDAO.Instance.GetMaxEmployeeId();
        }

        public string GenerateNewEmployeeId()
        {
            string maxId = MaxEmployeeId;
            Match match = Regex.Match(maxId, @"(\d+)$");
            string prefix = maxId.Substring(0, maxId.Length - match.Value.Length);
            int currentNumber = match.Success ? int.Parse(match.Value) : 0;
            int newNumber = currentNumber + 1;

            return prefix + newNumber.ToString();
        }

        public bool AddEmployee(string hoTen, string sdt, float luong, string diaChi, DateTime ngayVaoLam, string chucNang, out string newMaNV)
        {
            newMaNV = GenerateNewEmployeeId();

            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(sdt) || luong < 0 || string.IsNullOrWhiteSpace(chucNang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            // SỬA: Gọi DAO với tham số ref newMaNV
            bool success = EmployeeDAO.Instance.AddEmployeeAndAccount(
                newMaNV, hoTen, sdt, ngayVaoLam, luong, diaChi, chucNang, ref newMaNV
            );

            if (success)
            {
                MaxEmployeeId = newMaNV;
                string accountInfo = $"Mã NV/ID Tài khoản: **{newMaNV}**\n" +
                                     $"Mật khẩu mặc định: **{sdt}**\n" +
                                     $"Phân quyền: **{chucNang}**";

                MessageBox.Show($"Thêm nhân viên thành công!\n\nThông tin tài khoản vừa tạo:\n{accountInfo}",
                                "Thông báo tạo tài khoản", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return success;
        }

        public bool UpdateEmployee(string maNV, string hoTen, string sdt, float luong, string diaChi, DateTime ngayVaoLam, string chucNang)
        {
            if (string.IsNullOrWhiteSpace(maNV) || string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(sdt) || luong < 0 || string.IsNullOrWhiteSpace(chucNang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ và hợp lệ thông tin nhân viên.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            bool success = EmployeeDAO.Instance.UpdateEmployee(maNV, hoTen, sdt, ngayVaoLam, luong, diaChi, chucNang);

            if (success)
            {
                MessageBox.Show($"Cập nhật thông tin nhân viên {maNV} thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return success;
        }

        public bool DeleteEmployee(string maNV)
        {
            if (string.IsNullOrEmpty(maNV))
            {
                MessageBox.Show("Vui lòng chọn Mã Nhân viên cần xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa nhân viên {maNV} và tất cả tài khoản liên quan không?",
                                                  "Xác nhận xóa",
                                                  MessageBoxButtons.YesNo,
                                                  MessageBoxIcon.Warning);

            if (result == DialogResult.No) return false;

            bool success = EmployeeDAO.Instance.DeleteEmployeeAndAccount(maNV);

            if (success)
            {
                MaxEmployeeId = EmployeeDAO.Instance.GetMaxEmployeeId();
                MessageBox.Show("Xóa nhân viên và tài khoản liên quan thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            return success;
        }

        public List<EmployeeDTO> GetEmployeeList()
        {
            return EmployeeDAO.Instance.GetEmployeeList();
        }

        public List<EmployeeDTO> SearchEmployees(string keyword)
        {
            if (string.IsNullOrWhiteSpace(keyword))
            {
                return GetEmployeeList();
            }
            return EmployeeDAO.Instance.SearchEmployees(keyword);
        }
    }
}