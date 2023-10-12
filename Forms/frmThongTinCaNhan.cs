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
    public partial class frmThongTinCaNhan : Form
    {
        public User user = null;
        public frmThongTinCaNhan()
        {
            InitializeComponent();
        }

        private void frmThongTinCaNhan_Load(object sender, EventArgs e)
        {
            if(user == null)
            {
                MessageBox.Show("Vui lòng đăng nhập");
                this.Close();
            }
            txtID.Text = user.UserId.ToString();
            txtUsername.Text = user.Username;
            txtEmail.Text = user.Email;
            txtSDT.Text = user.SDT;
            txtRole.Text = user.Role.RoleName;
        }
    }
}
