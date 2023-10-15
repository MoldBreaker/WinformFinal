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
    public partial class frmQuanLyHoaDon : Form
    {
        public User user = null;
        private InvoiceService invoiceService = new InvoiceService();
        private UserService userService = new UserService();
        public frmQuanLyHoaDon()
        {
            InitializeComponent();
        }

        private void frmQuanLyHoaDon_Load(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Hãy đăng nhập để sử dụng chức năng này");
                this.Close();
                return;
            }
            List<Invoice> invoices = invoiceService.GetAllInvoices();
            FillDGV(invoices);
            CalcTotal(invoices);
        }

        private void FillDGV(List<Invoice> invoices)
        {
            dgvHoaDon.Rows.Clear();
            for(int i=0;i<invoices.Count;i++)
            {
                int index = dgvHoaDon.Rows.Add();
                dgvHoaDon.Rows[index].Cells[0].Value = invoices[i].InvoiceId;
                dgvHoaDon.Rows[index].Cells[1].Value = invoices[i].User.Username;
                dgvHoaDon.Rows[index].Cells[2].Value = invoices[i].CreatedAt;
                dgvHoaDon.Rows[index].Cells[3].Value = invoices[i].AfterDiscount;
                dgvHoaDon.Rows[index].Cells[4].Value = "Xem chi tiết hoá đơn";
                dgvHoaDon.Rows[index].Cells[5].Value = "Xem thông tin người mua";
                dgvHoaDon.Rows[index].Cells[6].Value = invoices[i].UserId;
            }
        }

        private void CalcTotal(List<Invoice> invoices)
        {
            double totalPrice = 0;
            for(int i = 0; i < invoices.Count; i++)
            {
                totalPrice += invoices[i].AfterDiscount;
            }
            txtTongDoanhThu.Text = totalPrice.ToString();
        }

        private void dgvHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int curretRow = dgvHoaDon.CurrentRow.Index;
                int currentCell = dgvHoaDon.CurrentCell.ColumnIndex;
                if (currentCell == 4)
                {
                    int invoiceId = int.Parse(dgvHoaDon.Rows[curretRow].Cells[0].Value.ToString());
                    Invoice invoice = invoiceService.GetInvoiceById(invoiceId);
                    frmChiTietHoaDon frmChiTietHoaDon = new frmChiTietHoaDon();
                    frmChiTietHoaDon.invoice = invoice;
                    frmChiTietHoaDon.ShowDialog();
                } else
                {
                    if(currentCell == 5)
                    {
                        int UserId = int.Parse(dgvHoaDon.Rows[curretRow].Cells[6].Value.ToString());
                        User user = userService.GetUserById(UserId);
                        frmThongTinCaNhan frmThongTinCaNhan = new frmThongTinCaNhan();
                        frmThongTinCaNhan.user = user;
                        frmThongTinCaNhan.ShowDialog();
                    }
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<Invoice> invoices = new List<Invoice>();
            string timKiem = txtTimKiem.Text;
            if (rdTenNguoiDung.Checked)
            {
                invoices = invoiceService.GetAllInvoices().Where(i => i.User.Username.ToUpper().Contains(timKiem.ToUpper())).ToList();
            } else
            {
                invoices = invoiceService.GetAllInvoices().Where(i => i.InvoiceId.ToString().Contains(timKiem)).ToList();
            }
            FillDGV(invoices);
        }
    }
}
