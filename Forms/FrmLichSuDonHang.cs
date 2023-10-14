using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DAL.Models;

namespace Forms
{
    public partial class FrmLichSuDonHang : Form
    {
        public User user = null;
        private InvoiceService invoiceService = new InvoiceService();
        public FrmLichSuDonHang()
        {
            InitializeComponent();
        }

        private void FrmLichSuDonHang_Load(object sender, EventArgs e)
        {
            if(user == null)
            {
                MessageBox.Show("Hãy đăng nhập để sử dụng chức năng này");
                this.Close();
                return;
            }
            List<Invoice> invoices = invoiceService.GetInvoicesByUserID(user.UserId);
            BindGrid(invoices);
        }
        private void BindGrid(List<Invoice> invoices)
        {
            dgvLichSu.Rows.Clear();
            foreach (Invoice invoice in invoices) 
            {
                int index = dgvLichSu.Rows.Add();
                dgvLichSu.Rows[index].Cells[0].Value = invoice.InvoiceId;
                dgvLichSu.Rows[index].Cells[1].Value = invoice.User.Username;
                dgvLichSu.Rows[index].Cells[2].Value = invoice.AfterDiscount;
                dgvLichSu.Rows[index].Cells[3].Value = invoice.CreatedAt;
            }
        }
        private void dgvLichSu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvLichSu.CurrentRow.Index;
                int invoiceID = int.Parse(dgvLichSu.Rows[index].Cells[0].Value.ToString());
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
