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
    public partial class frmDoiMatKhau : Form
    {
        public User user = null;
        private UserService userService = new UserService();
        public frmDoiMatKhau()
        {
            InitializeComponent();
        }

        private void btnDoiMatKhau_Click(object sender, EventArgs e)
        {
            try
            {
                string MKCu = txtMatKhauCu.Text;
                string MKMoi = txtMatKhauMoi.Text;
                string CMKMoi = txtCMatKhauMoi.Text;
                userService.ChangePassword(user.UserId, MKCu, MKMoi, CMKMoi);
                MessageBox.Show("Đổi Mật Khẩu Thành Công");
                this.Close();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmDoiMatKhau_Load(object sender, EventArgs e)
        {
            if(user == null)
            {
                MessageBox.Show("Vui lòng đăng nhập");
                this.Close();
            }
        }
    }
}
