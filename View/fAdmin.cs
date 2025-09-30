using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace QuanLyQuanCafe
{
    public partial class fAdmin : Form
    {
        private int lastAddedFoodId; // Biến lưu trữ MaSP của món vừa được thêm

        public fAdmin()
        {
            InitializeComponent();
            LoadFoodList();
            LoadEmployeeList(); // Khởi tạo Load Employee List
            SetupComboBoxes();
            UpdateMaSP(); // Ban đầu hiển thị MaSP tiếp theo
            UpdateEmployeeID(); // Ban đầu hiển thị MaNV tiếp theo
            lastAddedFoodId = FoodBUS.Instance.GetMaxFoodId(); // Khởi tạo với MaxFoodId hiện tại
        }

        private void ADMIN_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void lbAdmin_Click(object sender, EventArgs e)
        {
        }

        private void ADMIN_Load(object sender, EventArgs e)
        {
        }

        private void btnTKadmin_Click(object sender, EventArgs e)
        {
            fAccountProfile f = new fAccountProfile();
            this.Hide();
            f.ShowDialog();
            this.Show();
        }

        private void lblRevenue_Click(object sender, EventArgs e)
        {
        }

        private void label7_Click(object sender, EventArgs e)
        {
        }

        private void chart1_Click(object sender, EventArgs e)
        {
        }

        private void label4_Click(object sender, EventArgs e)
        {
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
        }

        private void tcQLmenu_Click(object sender, EventArgs e)
        {
        }

        // =======================================================
        // # REGION: QUẢN LÝ MÓN ĂN (FOOD)
        // =======================================================

        private void dgSp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgFood.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgFood.SelectedRows[0];
                tbTenMon.Text = row.Cells["TenSP"].Value?.ToString() ?? "";
                cbLoai.SelectedItem = row.Cells["LoaiSP"].Value?.ToString() ?? "Đồ ăn";
                tbGia.Text = row.Cells["DonGia"].Value?.ToString() ?? "";
                tbSoLuong.Text = row.Cells["SoLuong"].Value?.ToString() ?? "1";
                tbMaMon.Text = row.Cells["MaSP"].Value?.ToString() ?? "";
            }
        }

        private void LoadFoodList()
        {
            List<FoodDTO> foodList = FoodBUS.Instance.GetFoodList();
            dgFood.DataSource = foodList;
            dgFood.Columns["MaSP"].HeaderText = "Mã món";
            dgFood.Columns["TenSP"].HeaderText = "Tên món";
            dgFood.Columns["LoaiSP"].HeaderText = "Loại";
            dgFood.Columns["DonGia"].HeaderText = "Đơn giá";
            var soLuongColumn = dgFood.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name.Equals("SoLuong", StringComparison.OrdinalIgnoreCase));
            if (soLuongColumn != null)
            {
                soLuongColumn.HeaderText = "Số lượng";
            }

            dgFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgFood.ScrollBars = ScrollBars.Both;
            dgFood.Columns["MaSP"].Width = 100;
            dgFood.Columns["TenSP"].Width = 150;
            dgFood.Columns["LoaiSP"].Width = 100;
            dgFood.Columns["DonGia"].Width = 100;
            if (soLuongColumn != null)
            {
                soLuongColumn.Width = 100;
            }
            dgFood.AllowUserToAddRows = false;
            dgFood.ReadOnly = true;
            dgFood.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFood.MultiSelect = false;
            dgFood.RowHeadersVisible = false;
        }

        private void UpdateMaSP()
        {
            int maxId = FoodBUS.Instance.GetMaxFoodId();
            tbMaMon.Text = (maxId + 1).ToString();
            tbMaMon.ReadOnly = true;
            Console.WriteLine($"UpdateMaSP: MaxFoodId = {maxId}, tbMaMon = {tbMaMon.Text}");
        }

        private void SetupComboBoxes()
        {
            cbLoai.Items.Clear();
            cbFilter.Items.Clear();
            cbFilter.Items.Add("Tất cả");
            cbLoai.Items.Add("Đồ ăn");
            cbLoai.Items.Add("Đồ uống");
            cbFilter.Items.Add("Đồ ăn");
            cbFilter.Items.Add("Đồ uống");
            cbLoai.SelectedIndex = 0;
            cbFilter.SelectedIndex = 0;
        }

        private void btnAddMon_Click(object sender, EventArgs e)
        {
            string name = tbTenMon.Text.Trim();
            string category = cbLoai.SelectedItem?.ToString();

            if (float.TryParse(tbGia.Text.Trim(), out float price) &&
                int.TryParse(tbSoLuong.Text.Trim(), out int soLuong) &&
                !string.IsNullOrEmpty(name) && category != null && price >= 0 && soLuong >= 0)
            {
                int newId = FoodBUS.Instance.AddFood(name, category, price, soLuong);
                if (newId > 0)
                {
                    MessageBox.Show("Thêm món thành công! Mã món: " + newId.ToString());
                    lastAddedFoodId = newId;

                    LoadFoodList();
                    dgFood.Refresh();

                    tbTenMon.Text = "";
                    tbGia.Text = "";
                    cbLoai.SelectedIndex = 0;
                    tbSoLuong.Text = "1";

                    UpdateMaSP();
                    dgFood.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Thêm món thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ (Đơn giá và Số lượng phải là số >= 0)!");
            }
        }

        private void btnXoaMon_Click(object sender, EventArgs e)
        {
            if (dgFood.SelectedRows.Count > 0)
            {
                int id = (int)dgFood.SelectedRows[0].Cells["MaSP"].Value;
                if (FoodBUS.Instance.DeleteFood(id))
                {
                    MessageBox.Show("Xóa món thành công!");
                    LoadFoodList();
                    dgFood.Refresh();
                    tbTenMon.Text = "";
                    tbGia.Text = "";
                    tbSoLuong.Text = "1";
                    UpdateMaSP();
                    lastAddedFoodId = FoodBUS.Instance.GetMaxFoodId();
                }
                else
                {
                    MessageBox.Show("Xóa món thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món để xóa!");
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (dgFood.SelectedRows.Count > 0)
            {
                int id = (int)dgFood.SelectedRows[0].Cells["MaSP"].Value;
                string name = tbTenMon.Text.Trim();
                string category = cbLoai.SelectedItem?.ToString();

                if (float.TryParse(tbGia.Text.Trim(), out float price) &&
                    int.TryParse(tbSoLuong.Text.Trim(), out int soLuong) &&
                    !string.IsNullOrEmpty(name) && category != null && price >= 0 && soLuong >= 0)
                {
                    if (FoodBUS.Instance.UpdateFood(id, name, category, price, soLuong))
                    {
                        MessageBox.Show("Cập nhật món thành công!");
                        int selectedRowIndex = dgFood.SelectedRows[0].Index;
                        LoadFoodList();
                        dgFood.Refresh();
                        if (selectedRowIndex < dgFood.Rows.Count)
                        {
                            dgFood.Rows[selectedRowIndex].Selected = true;
                            tbMaMon.Text = id.ToString();
                        }
                        lastAddedFoodId = FoodBUS.Instance.GetMaxFoodId();
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật món thất bại!");
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ (Đơn giá và Số lượng phải là số >= 0)!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một món để cập nhật!");
            }
        }

        private void cbFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            string category = cbFilter.SelectedItem?.ToString();
            Console.WriteLine($"Đã chọn loại: '{category}'");
            if (category != null)
            {
                List<FoodDTO> foodList;
                if (category == "Tất cả")
                {
                    foodList = FoodBUS.Instance.GetFoodList();
                }
                else
                {
                    foodList = FoodBUS.Instance.FilterFood(category);
                }
                Console.WriteLine($"Số món tìm thấy: {foodList.Count}");
                dgFood.DataSource = foodList;
                dgFood.Columns["MaSP"].Visible = true;
                dgFood.Columns["TenSP"].HeaderText = "Tên món";
                dgFood.Columns["LoaiSP"].HeaderText = "Loại";
                dgFood.Columns["DonGia"].HeaderText = "Đơn giá";
                var soLuongColumn = dgFood.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name.Equals("SoLuong", StringComparison.OrdinalIgnoreCase));
                if (soLuongColumn != null)
                {
                    soLuongColumn.HeaderText = "Số lượng";
                }
                dgFood.Refresh();
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại để lọc!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            UpdateMaSP();
            tbTenMon.Text = "";
            tbGia.Text = "";
            tbSoLuong.Text = "1";
            cbLoai.SelectedIndex = 0;
            lastAddedFoodId = FoodBUS.Instance.GetMaxFoodId();
            dgFood.ClearSelection();
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            LoadFoodList();
            lastAddedFoodId = FoodBUS.Instance.GetMaxFoodId();
            UpdateMaSP();
            MessageBox.Show("Danh sách đã được làm mới từ cơ sở dữ liệu!");
        }

        private void btnTimKiem_Click_1(object sender, EventArgs e)
        {
            string keyword = tbTimKiem.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadFoodList();
                MessageBox.Show("Vui lòng nhập Mã món, Tên món, hoặc Giá để tìm kiếm.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                btnClear_Click(null, null);
                return;
            }

            List<FoodDTO> searchResult = FoodBUS.Instance.SearchFood(keyword);

            if (searchResult.Count > 0)
            {
                dgFood.DataSource = searchResult;
                MessageBox.Show($"Đã tìm thấy {searchResult.Count} món ăn.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                var soLuongColumn = dgFood.Columns.Cast<DataGridViewColumn>().FirstOrDefault(c => c.Name.Equals("SoLuong", StringComparison.OrdinalIgnoreCase));
                if (soLuongColumn != null)
                {
                    soLuongColumn.HeaderText = "Số lượng";
                }
                dgFood.Refresh();
            }
            else
            {
                dgFood.DataSource = null;
                MessageBox.Show("Không tìm thấy món ăn nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnClear_Click(null, null);
        }

        private void tbSoLuong_TextChanged(object sender, EventArgs e)
        {
        }

        // =======================================================
        // # REGION: QUẢN LÝ NHÂN VIÊN (EMPLOYEE)
        // =======================================================

        private void panel6_Paint(object sender, PaintEventArgs e)
        {
        }

        private void LoadEmployeeList()
        {
            List<EmployeeDTO> employeeList = EmployeeBUS.Instance.GetEmployeeList();
            Console.WriteLine($"LoadEmployeeList: Đã tải {employeeList.Count} nhân viên");
            dgvEmployeeView.DataSource = null;
            dgvEmployeeView.DataSource = employeeList;

            if (dgvEmployeeView.Columns.Contains("AccountID"))
            {
                dgvEmployeeView.Columns["AccountID"].Visible = false;
            }

            dgvEmployeeView.Columns["MaNV"].HeaderText = "Mã NV";
            dgvEmployeeView.Columns["HoTen"].HeaderText = "Họ Tên";
            dgvEmployeeView.Columns["SDT"].HeaderText = "SĐT (Tên đăng nhập)";
            dgvEmployeeView.Columns["NgayVaoLam"].HeaderText = "Ngày vào làm";
            dgvEmployeeView.Columns["Luong"].HeaderText = "Lương";
            dgvEmployeeView.Columns["DiaChi"].HeaderText = "Địa chỉ";
            dgvEmployeeView.Columns["TenChucNang"].HeaderText = "Chức năng";

            dgvEmployeeView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            dgvEmployeeView.ScrollBars = ScrollBars.Both;
            dgvEmployeeView.Columns["MaNV"].Width = 100;
            dgvEmployeeView.Columns["HoTen"].Width = 150;
            dgvEmployeeView.Columns["SDT"].Width = 120;
            dgvEmployeeView.Columns["NgayVaoLam"].Width = 100;
            dgvEmployeeView.Columns["Luong"].Width = 100;
            dgvEmployeeView.Columns["DiaChi"].Width = 200;
            dgvEmployeeView.Columns["TenChucNang"].Width = 100;

            dgvEmployeeView.AllowUserToAddRows = false;
            dgvEmployeeView.ReadOnly = true;
            dgvEmployeeView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvEmployeeView.MultiSelect = false;
            dgvEmployeeView.RowHeadersVisible = false;
            dgvEmployeeView.Refresh();
        }

        private void UpdateEmployeeID()
        {
            txxtEmployeeID.Text = EmployeeBUS.Instance.GenerateNewEmployeeId();
            txxtEmployeeID.ReadOnly = true;
        }

        private void dgvEmployeeView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgvEmployeeView.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvEmployeeView.SelectedRows[0];
                txxtEmployeeID.Text = row.Cells["MaNV"].Value?.ToString() ?? "";
                txtEmployeeName.Text = row.Cells["HoTen"].Value?.ToString() ?? "";
                txtPhone.Text = row.Cells["SDT"].Value?.ToString() ?? "";
                if (row.Cells["NgayVaoLam"].Value != null && DateTime.TryParse(row.Cells["NgayVaoLam"].Value.ToString(), out DateTime ngayVaoLam))
                {
                    dtpEmployeeStart.Value = ngayVaoLam;
                }
                txtEmployeeSalary.Text = row.Cells["Luong"].Value?.ToString() ?? "";
                txtEmployeeAddress.Text = row.Cells["DiaChi"].Value?.ToString() ?? "";
                txtTenChucNang.Text = row.Cells["TenChucNang"].Value?.ToString() ?? "";
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (dgvEmployeeView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để xóa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = dgvEmployeeView.SelectedRows[0].Cells["MaNV"].Value?.ToString();

            if (!string.IsNullOrEmpty(maNV))
            {
                try
                {
                    bool success = EmployeeBUS.Instance.DeleteEmployee(maNV);
                    if (success)
                    {
                        MessageBox.Show("Xóa nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeList();
                        dgvEmployeeView.Refresh();
                        btnEmployeeClear_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Xóa nhân viên thất bại! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi xóa nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void btnEmployeeSearch_Click(object sender, EventArgs e)
        {
            string keyword = tbEmployeeSearch.Text.Trim();

            if (string.IsNullOrEmpty(keyword))
            {
                LoadEmployeeList();
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm (Tên, SĐT, Mã NV).", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            List<EmployeeDTO> searchResult = EmployeeBUS.Instance.SearchEmployees(keyword);

            if (searchResult.Count > 0)
            {
                dgvEmployeeView.DataSource = null;
                dgvEmployeeView.DataSource = searchResult;
                MessageBox.Show($"Đã tìm thấy {searchResult.Count} nhân viên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dgvEmployeeView.Refresh();
            }
            else
            {
                dgvEmployeeView.DataSource = null;
                MessageBox.Show("Không tìm thấy nhân viên nào phù hợp.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

            btnEmployeeClear_Click(null, null);
        }

        private void tbEmployeeSearch_TextChanged(object sender, EventArgs e)
        {
        }

        private void txxtEmployeeID_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtEmployeeName_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtEmployeeSalary_TextChanged(object sender, EventArgs e)
        {
        }

        private void txtEmployeeAddress_TextChanged(object sender, EventArgs e)
        {
        }

        private void dtpEmployeeStart_ValueChanged(object sender, EventArgs e)
        {
        }

        private void btnEmployeeAdd_Click(object sender, EventArgs e)
        {
            string hoTen = txtEmployeeName.Text.Trim();
            string sdt = txtPhone.Text.Trim();
            string diaChi = txtEmployeeAddress.Text.Trim();
            DateTime ngayVaoLam = dtpEmployeeStart.Value;
            string chucNang = txtTenChucNang.Text.Trim();
            string newMaNV = string.Empty;

            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(chucNang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin: Họ tên, SĐT và Chức năng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (float.TryParse(txtEmployeeSalary.Text.Trim(), out float luong) && luong >= 0)
            {
                try
                {
                    bool success = EmployeeBUS.Instance.AddEmployee(hoTen, sdt, luong, diaChi, ngayVaoLam, chucNang, out newMaNV);
                    if (success)
                    {
                        MessageBox.Show($"Thêm nhân viên thành công! Mã NV: {newMaNV}", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeList();
                        dgvEmployeeView.Refresh();
                        btnEmployeeClear_Click(null, null);
                    }
                    else
                    {
                        MessageBox.Show("Thêm nhân viên thất bại! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi thêm nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Lương hợp lệ (phải là số và >= 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEmployeeEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployeeView.SelectedRows.Count == 0)
            {
                MessageBox.Show("Vui lòng chọn một nhân viên để sửa.", "Cảnh báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string maNV = txxtEmployeeID.Text.Trim();
            string hoTen = txtEmployeeName.Text.Trim();
            string sdt = txtPhone.Text.Trim();
            string diaChi = txtEmployeeAddress.Text.Trim();
            DateTime ngayVaoLam = dtpEmployeeStart.Value;
            string chucNang = txtTenChucNang.Text.Trim();

            if (string.IsNullOrWhiteSpace(hoTen) || string.IsNullOrWhiteSpace(sdt) || string.IsNullOrWhiteSpace(chucNang))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin: Họ tên, SĐT và Chức năng.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (float.TryParse(txtEmployeeSalary.Text.Trim(), out float luong) && luong >= 0)
            {
                try
                {
                    bool success = EmployeeBUS.Instance.UpdateEmployee(maNV, hoTen, sdt, luong, diaChi, ngayVaoLam, chucNang);
                    if (success)
                    {
                        MessageBox.Show("Cập nhật nhân viên thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        LoadEmployeeList();
                        dgvEmployeeView.Refresh();
                        foreach (DataGridViewRow row in dgvEmployeeView.Rows)
                        {
                            if (row.Cells["MaNV"].Value?.ToString() == maNV)
                            {
                                row.Selected = true;
                                dgvEmployeeView.FirstDisplayedScrollingRowIndex = row.Index;
                                txxtEmployeeID.Text = maNV;
                                break;
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("Cập nhật nhân viên thất bại! Vui lòng kiểm tra lại.", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Lỗi khi cập nhật nhân viên: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập Lương hợp lệ (phải là số và >= 0).", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnEmployeeClear_Click(object sender, EventArgs e)
        {
            UpdateEmployeeID();
            txtEmployeeName.Text = "";
            txtPhone.Text = "";
            txtEmployeeSalary.Text = "";
            txtEmployeeAddress.Text = "";
            txtTenChucNang.Text = "";
            dtpEmployeeStart.Value = DateTime.Now;
            dgvEmployeeView.ClearSelection();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            LoadEmployeeList();
            dgvEmployeeView.Refresh();
            btnEmployeeClear_Click(null, null);
            MessageBox.Show("Danh sách nhân viên đã được làm mới.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void txtTenChucNang_TextChanged(object sender, EventArgs e)
        {
        }

        private void tpQLNV_Click(object sender, EventArgs e)
        {
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
        }
    }
}