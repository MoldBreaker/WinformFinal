using BLL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class frmDangNhap : Form
    {
        private RoleService roleService = new RoleService();
        private UserService userService = new UserService();
        public frmDangNhap()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void btnThoat_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void DangNhap_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (MessageBox.Show("Bạn có chắn chắn muốn thoát", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.Cancel)
            {
                e.Cancel = true;
            }
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            frmDangKi DangKi = new frmDangKi();
            this.Hide();
            DangKi.ShowDialog();
            this.Show();
        }

        private void btnDangNhap_Click(object sender, EventArgs e)
        {
            try
            {
                string email = txtEmail.Text;
                string password = txtMatKhau.Text;

                User userLogin = new User();
                userLogin.Email = email;
                userLogin.Password = password;  

                User user = userService.Login(userLogin);
                MessageBox.Show("Đăng nhập thành công");
                txtEmail.Text = "";
                txtMatKhau.Text = "";
                switch (user.RoleId)
                {
                    case "KH":
                        frmKhachHang formKhachHang = new frmKhachHang();
                        this.Hide();
                        formKhachHang.ShowDialog();
                        this.Show();
                        break;
                    case "NV":
                        frmNhanVien formNhanVien = new frmNhanVien();
                        this.Hide();
                        formNhanVien.ShowDialog();
                        this.Show();
                        break;
                    case "QL":
                        frmQuanLy formQuanLy = new frmQuanLy();
                        this.Hide();
                        formQuanLy.ShowDialog();
                        this.Show();
                        break;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
