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
    public partial class frmDangKi : Form
    {
        private UserService UserService = new UserService();
        public frmDangKi()
        {
            InitializeComponent();
        }

        private void btnDangKi_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text;
                string email = txtEmail.Text;
                string phone = txtSDT.Text;
                string password = txtMatKhau.Text;
                string cpassword = txtNhapLaiMK.Text;
                if(cpassword != password)
                {
                    throw new Exception("Mật khẩu không trùng nhau");
                }
                User user = new User();
                user.Username = username;
                user.Email = email;
                user.SDT = phone;
                user.Password = password;
                UserService.Register(user);
                MessageBox.Show("Đăng kí thành công");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmDangKi_Load(object sender, EventArgs e)
        {

        }
    }
}
