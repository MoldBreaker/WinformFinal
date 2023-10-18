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
    public partial class frmThongTinThe : Form
    {
        public User user = null;
        private CardService cardService = new CardService();
        public frmThongTinThe()
        {
            InitializeComponent();
        }

        private void frmThongTinThe_Load(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Vui lòng đăng nhập để sử dụng chức năng này");
                this.Close();
                return;
            }
            Card card = cardService.GetCardByUserId(user.UserId);
            txtMaThe.Text = card.CardNumber;
            txtNguoiSoHuu.Text = card.User.Username;
            txtDiem.Text = card.Point.ToString();
            txtXepHang.Text = card.Rank;
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnHuyThe_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Bạn có chắc chắn muốn huỷ thể, tất cả điểm bạn đã tích sẽ mất", "Cảnh Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Card card = new Card();
                    card.CardNumber = txtMaThe.Text;
                    cardService.DeletaCard(card);
                    this.Close();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
