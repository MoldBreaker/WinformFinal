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

    public partial class frmChiTietHoaDon : Form
    {
        public Invoice invoice = null;
        private InvoiceDetailService invoiceDetailService = new InvoiceDetailService();
        public frmChiTietHoaDon()
        {
            InitializeComponent();
        }

        private void frmChiTietHoaDon_Load(object sender, EventArgs e)
        {
            if(invoice == null) 
            {
                MessageBox.Show("Mã hóa đơn không hợp lệ");
                this.Close();
                return;
            }
            List<InvoiceDetail> invoiceDetails = invoiceDetailService.GetInvoiceDetailsByInvoiceID(invoice.InvoiceId);
            BindGrid(invoiceDetails);
            FillTextBoxData();
        }

        private void FillTextBoxData()
        {
            txtMaHD.Text = invoice.InvoiceId.ToString();
            txtNguoiMua.Text = invoice.User.Username;
            txtThoiGianMua.Text = invoice.CreatedAt.ToString("HH:mm dd/MM/yyyy");
            txtTongTien.Text = invoice.TotalPrice.ToString();
            txtGiamGia.Text = invoice.Discount.ToString();
            txtSoTienPhaiTra.Text = invoice.AfterDiscount.ToString();
        }

        private void BindGrid(List<InvoiceDetail> invoicedetails)
        {
            dgvChiTiet.Rows.Clear();
            foreach (InvoiceDetail detail in invoicedetails)
            {
                int index = dgvChiTiet.Rows.Add();
                dgvChiTiet.Rows[index].Cells[0].Value = detail.Product.ProductName;
                dgvChiTiet.Rows[index].Cells[1].Value = detail.Quantity;
                dgvChiTiet.Rows[index].Cells[2].Value = detail.Product.SellPrice;
                dgvChiTiet.Rows[index].Cells[3].Value = detail.Price;
            }
        }
    }
}
