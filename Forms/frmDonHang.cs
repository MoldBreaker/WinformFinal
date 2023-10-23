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
    public partial class frmDonHang : Form
    {
        private InvoiceService invoiceService = new InvoiceService();
        public frmDonHang()
        {
            InitializeComponent();
        }

        private void frmDonHang_Load(object sender, EventArgs e)
        {
            List<Invoice> invoices = invoiceService.GetAllInvoices();
            rbAll.Checked = true;
            BindGrid(invoices);
        }
        private void BindGrid(List<Invoice> invoices)
        {
            dgvOrderHistory.Rows.Clear();
            foreach (Invoice invoice in invoices)
            {
                int index = dgvOrderHistory.Rows.Add();
                dgvOrderHistory.Rows[index].Cells[0].Value = invoice.InvoiceId;
                dgvOrderHistory.Rows[index].Cells[1].Value = invoice.User.Username;
                dgvOrderHistory.Rows[index].Cells[2].Value = invoice.AfterDiscount;
                dgvOrderHistory.Rows[index].Cells[3].Value = invoice.CreatedAt;
            }
        }

        private void rbAll_CheckedChanged(object sender, EventArgs e)
        {
            List<Invoice> invoices = invoiceService.GetAllInvoices();
            BindGrid(invoices);
        }

        private void rbToday_CheckedChanged(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            List<Invoice> invoices = invoiceService.GetInvoicesByDate(today);
            BindGrid(invoices);
        }

        private void btnFind_Click(object sender, EventArgs e)
        {
            int id = int.Parse(txtFind.Text);
            Invoice invoice = invoiceService.GetInvoiceById(id);
            if(invoice == null)
            {
                MessageBox.Show("Không có đơn hàng này");
            }    
            else
            {
                dgvOrderHistory.Rows.Clear();
                int index = dgvOrderHistory.Rows.Add();
                dgvOrderHistory.Rows[index].Cells[0].Value = invoice.InvoiceId;
                dgvOrderHistory.Rows[index].Cells[1].Value = invoice.User.Username;
                dgvOrderHistory.Rows[index].Cells[2].Value = invoice.AfterDiscount;
                dgvOrderHistory.Rows[index].Cells[3].Value = invoice.CreatedAt;
            }    
            txtFind.Text = "";
        }

        private void dgvLichSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvOrderHistory.CurrentRow.Index;
                int invoiceID = int.Parse(dgvOrderHistory.Rows[index].Cells[0].Value.ToString());
                Invoice invoice = invoiceService.GetInvoiceById(invoiceID);
                frmChiTietHoaDon frmChiTietHoaDon = new frmChiTietHoaDon();
                frmChiTietHoaDon.invoice = invoice;
                frmChiTietHoaDon.ShowDialog();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
