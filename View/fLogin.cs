
using QuanLyQuanCafe.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using QuanLyQuanCafe.BUS;
using QuanLyQuanCafe.DTO;

namespace QuanLyQuanCafe
{
    public partial class fLogin : Form
    {
        private string selectedRole;
        public fLogin(string role)
        {
            InitializeComponent();
            this.selectedRole = role;
        }

        private void fLogin_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        // Thoát khỏi form đăng nhập
        private void Exit_Click(object sender, EventArgs e)
        {
            Application.Exit();

        }
        // Thông báo xác nhận đóng form đăng nhập
        private void fLogin_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có thật sự muốn thoát chương trình?", "Thông báo", MessageBoxButtons.OKCancel) != System.Windows.Forms.DialogResult.OK)
            {
                e.Cancel = true;
            }
        }
        private void txbPassword_TextChanged(object sender, EventArgs e)
        {

        }

        private void LOGIN_Click(object sender, EventArgs e)
        {
            string userName = txbUserName.Text.Trim();
            string passWord = txbPassword.Text.Trim();

            if (string.IsNullOrEmpty(userName) || string.IsNullOrEmpty(passWord))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ tên đăng nhập và mật khẩu!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            LoginResult result = AccountBUS.Instance.Login(userName, passWord, selectedRole, out AccountDTO account);

            switch (result)
            {
                case LoginResult.Success:
                    if (selectedRole == "admin")
                    {
                        fAdmin f = new fAdmin();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                    }
                    else // staff hoặc cashier
                    {
                        fNhanvien f = new fNhanvien();
                        this.Hide();
                        f.ShowDialog();
                        this.Show();
                    }
                    break;
                case LoginResult.WrongUserPass:
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
                case LoginResult.WrongRole:
                    MessageBox.Show($"Tài khoản không có quyền {selectedRole}!", "Lỗi đăng nhập", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    break;
            }
        }
        private void txbUserName_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbName_Click(object sender, EventArgs e)
        {

        }
    }
}
