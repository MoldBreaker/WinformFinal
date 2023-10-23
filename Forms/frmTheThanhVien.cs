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
            if(phoneNumber.Trim().Length == 0)
            {
                MessageBox.Show("Phải nhập sdt");
            } else if (!Validator.IsValidPhone(phoneNumber))
            {
                MessageBox.Show("SDT không hợp lệ");
            }
            else
            {
                var query = from u in dBContext.Users
                            join c in dBContext.Cards on u.UserId equals c.UserId
                            where u.SDT == phoneNumber
                            select c;
                card = query.FirstOrDefault();
                User user = userService.GetUserByPhone(phoneNumber);
                if (card == null)
                {
                    MessageBox.Show("Khách hàng này chưa có thẻ thành viên");
                    //Close();
                }
                else
                {
                    txtCardID.Text = card.CardNumber;
                    txtUserID.Text = user.UserId.ToString();
                    txtUserName.Text = user.Username;
                    txtRank.Text = card.Rank;
                    txtPoint.Text = card.Point.ToString();
                }
            }
        }

        public bool ConfirmButtonClicked { get; private set; }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if(txtCardID.Text.Trim().Length == 0)
            {
                MessageBox.Show("Chưa chọn được khách hàng");
            } else
            {
                ConfirmButtonClicked = true;
                this.Close();
            }
        }
    }
}
