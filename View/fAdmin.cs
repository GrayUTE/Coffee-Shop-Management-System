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
            SetupComboBoxes();
            UpdateMaSP(); // Ban đầu hiển thị MaSP tiếp theo
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

        private void dgSp_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (dgFood.SelectedRows.Count > 0)
            {
                // Sử dụng dgFood.SelectedRows[0] để lấy dữ liệu của hàng được chọn
                DataGridViewRow row = dgFood.SelectedRows[0];
                tbTenMon.Text = row.Cells["TenSP"].Value?.ToString() ?? "";
                cbLoai.SelectedItem = row.Cells["LoaiSP"].Value?.ToString() ?? "Đồ ăn";
                tbGia.Text = row.Cells["DonGia"].Value?.ToString() ?? "";
                // Hiển thị MaSP của món được chọn
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
            dgFood.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgFood.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.AllCells;
            dgFood.AllowUserToAddRows = false;
            dgFood.ReadOnly = true;
            dgFood.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgFood.MultiSelect = false;
            dgFood.RowHeadersVisible = false;
        }

        // HÀM NÀY CHỈ CẬP NHẬT tbMaMon VỀ ID TIẾP THEO
        private void UpdateMaSP()
        {
            // Luôn truy vấn DB để lấy MaSP lớn nhất hiện tại
            int maxId = FoodBUS.Instance.GetMaxFoodId();
            // HIỂN THỊ MÃ SẢN PHẨM TIẾP THEO SẼ ĐƯỢC THÊM VÀO
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

        // ĐÃ SỬA ĐỔI: Sau khi thêm thành công, chỉ cập nhật Mã món và xóa trắng các trường khác.
        private void btnAddMon_Click(object sender, EventArgs e)
        {
            string name = tbTenMon.Text.Trim();
            string category = cbLoai.SelectedItem?.ToString();
            // SỬA ĐỔI: Dùng float.TryParse để khớp với DonGia (float)
            if (float.TryParse(tbGia.Text.Trim(), out float price) &&
                !string.IsNullOrEmpty(name) && category != null && price >= 0)
            {
                int newId = FoodBUS.Instance.AddFood(name, category, price);
                if (newId > 0)
                {
                    MessageBox.Show("Thêm món thành công! Mã món: " + newId.ToString());
                    lastAddedFoodId = newId;

                    LoadFoodList(); // Tải lại danh sách để hiển thị món mới

                    // XÓA TRẮNG CÁC TRƯỜNG NỘI DUNG (TÊN, GIÁ, LOẠI)
                    tbTenMon.Text = "";
                    tbGia.Text = "";
                    cbLoai.SelectedIndex = 0;

                    // CẬP NHẬT tbMaMon VỀ ID TIẾP THEO (MAX ID + 1)
                    UpdateMaSP();

                    // XÓA CHỌN TRONG DATAGRIDVIEW
                    dgFood.ClearSelection();
                }
                else
                {
                    MessageBox.Show("Thêm món thất bại!");
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ (Đơn giá phải là số >= 0)!");
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
                    tbTenMon.Text = "";
                    tbGia.Text = "";
                    UpdateMaSP(); // Cập nhật tbMaMon với MaSP lớn nhất + 1 sau khi xóa
                    lastAddedFoodId = FoodBUS.Instance.GetMaxFoodId(); // Cập nhật lastAddedFoodId
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
                // Đảm bảo lấy ID từ hàng đang được chọn (dgFood.SelectedRows[0])
                int id = (int)dgFood.SelectedRows[0].Cells["MaSP"].Value;
                string name = tbTenMon.Text.Trim();
                string category = cbLoai.SelectedItem?.ToString();
                // SỬA ĐỔI: Dùng float.TryParse để khớp với DonGia (float)
                if (float.TryParse(tbGia.Text.Trim(), out float price) && !string.IsNullOrEmpty(name) && category != null && price >= 0)
                {
                    if (FoodBUS.Instance.UpdateFood(id, name, category, price))
                    {
                        MessageBox.Show("Cập nhật món thành công!");

                        // Lấy chỉ mục hàng đang được chọn trước khi tải lại
                        int selectedRowIndex = dgFood.SelectedRows[0].Index;

                        LoadFoodList();

                        // Tái chọn hàng vừa cập nhật (giữ lại vị trí chọn)
                        if (selectedRowIndex < dgFood.Rows.Count)
                        {
                            dgFood.Rows[selectedRowIndex].Selected = true;
                            // Cập nhật lại textbox MaMon (giữ ID đã chọn)
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
                    MessageBox.Show("Vui lòng nhập đầy đủ thông tin hợp lệ (Đơn giá phải là số >= 0)!");
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
            }
            else
            {
                MessageBox.Show("Vui lòng chọn loại để lọc!");
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Hiển thị ID tiếp theo (Max + 1) để chuẩn bị cho thao tác thêm mới
            UpdateMaSP();
            tbTenMon.Text = "";
            tbGia.Text = "";
            cbLoai.SelectedIndex = 0;
            lastAddedFoodId = FoodBUS.Instance.GetMaxFoodId();
            dgFood.ClearSelection(); // Xóa chọn
        }

        private void btnLuu_Click_1(object sender, EventArgs e)
        {
            LoadFoodList(); // Tải lại danh sách món từ cơ sở dữ liệu
            lastAddedFoodId = FoodBUS.Instance.GetMaxFoodId();
            UpdateMaSP(); // Cập nhật tbMaMon với MaSP lớn nhất + 1 từ DB
            MessageBox.Show("Danh sách đã được làm mới từ cơ sở dữ liệu!");
        }
    }
}