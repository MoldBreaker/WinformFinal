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
    public partial class frmTheThanhVien : Form
    {
        public UserService userService = new UserService();
        public Card card;
        DBContext dBContext;
        public frmTheThanhVien()
        {
            InitializeComponent();
            dBContext = new DBContext();
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            string phoneNumber = txtPhoneNumber.Text;
            var query = from u in dBContext.Users 
                        join c in dBContext.Cards on u.UserId equals c.UserId
                        where u.SDT == phoneNumber
                        select c;
            card = query.FirstOrDefault();
            User user = userService.GetUserByPhone(phoneNumber);
            txtUserID.Text = user.UserId.ToString();
            txtUserName.Text = user.Username;
            if(card.CardNumber != null)
                txtCardID.Text = card.CardNumber;
            if (card.Rank != null)
                txtRank.Text = card.Rank;
            if (card.Point != null)
                txtPoint.Text = card.Point.ToString();
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
