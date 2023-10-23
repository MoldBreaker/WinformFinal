using BLL;
using DAL.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class frmQuanLyThongKe : Form
    {
        private InvoiceService invoiceService = new InvoiceService();
        private ProductService ProductService = new ProductService();
        private UserService UserService = new UserService();
        public frmQuanLyThongKe()
        {
            InitializeComponent();
        }

        private void frmQuanLyThongKe_Load(object sender, EventArgs e)
        {
            try
            {
                FillDataChartWeek();
                FillDataChartMonth();
                BindDGVTopSellers();
                BindDGVTopUsers();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BindDGVTopUsers()
        {
            List<User> users = UserService.GetTopUsers();
            foreach (User user in users)
            {
                int index = dgvTopUsers.Rows.Add();
                dgvTopUsers.Rows[index].Cells[0].Value = index + 1;
                dgvTopUsers.Rows[index].Cells[1].Value = user.Username;
                dgvTopUsers.Rows[index].Cells[2].Value = user.Invoices.Sum(i => i.AfterDiscount);
            }
        }

        private void BindDGVTopSellers()
        {
            List<Product> products = ProductService.GetTopSellers();
            for (int i = 0; i < 5; i++)
            {
                int index = dgvTopSellers.Rows.Add();
                dgvTopSellers.Rows[index].Cells[0].Value = index + 1;
                try
                {
                    dgvTopSellers.Rows[index].Cells[1].Value = products[i].ProductName;
                }
                catch
                {
                    dgvTopSellers.Rows[index].Cells[1].Value = "Tìm Thời Chưa Có";
                }
            }
        }

        private void FillDataChartWeek()
        {
            DateTime currentTime = DateTime.Now;
            for (int i = 0; i < 5; i++)
            {
                chDoanhThuTheoTuan.Series["DoanhThu"].Points.AddXY((i == 0) ? "Hiện tại" : $"{i} tuần trước", invoiceService.GetInvoicesByDayOfWeek(currentTime));
                currentTime = currentTime.AddDays(-7);
            }
        }

        private void FillDataChartMonth()
        {
            DateTime currentTime = DateTime.Now;
            for (int i = 0; i < 5; i++)
            {
                currentTime = currentTime.AddMonths(-i);
                string monthLabel = (i == 0) ? "Hiện tại" : $"{i} tháng trước";
                DateTime firstDayOfMonth = new DateTime(currentTime.Year, currentTime.Month, 1);
                DateTime lastDayOfMonth = firstDayOfMonth.AddMonths(1).AddDays(-1);

                double totalRevenue = invoiceService.GetTotalRevenueByMonth(firstDayOfMonth);

                chThongKeTheoThang.Series["DoanhThu"].Points.AddXY(monthLabel, totalRevenue);

            }
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            frmQuanLyThongKe_Load(sender, e);
        }

        
    }
}
