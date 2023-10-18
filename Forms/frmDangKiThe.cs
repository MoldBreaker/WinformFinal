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
    public partial class frmDangKiThe : Form
    {
        public User user = null;
        private CardService cardService = new CardService();
        public frmDangKiThe()
        {
            InitializeComponent();
        }

        private void frmDangKiThe_Load(object sender, EventArgs e)
        {
            if(user == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để sử dụng chức năng này");
                this.Close();
                return;
            }
            txtMaThe.Text = user.SDT;
            txtNguoiSoHuu.Text = user.Username;
        }

        private void btnDangKyThe_Click(object sender, EventArgs e)
        {
            try
            {
                Card newCard = new Card();
                newCard.CardNumber = txtMaThe.Text;
                newCard.UserId = user.UserId;
                cardService.RegisterCard(newCard);
                MessageBox.Show("Đăng ký thành công");
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
