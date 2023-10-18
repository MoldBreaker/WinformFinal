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
        private ProductService productService = new ProductService();
        private InvoiceService invoiceService = new InvoiceService();
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
                FillTopProduct();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void FillDataChartWeek()
        {
            DateTime currentTime = DateTime.Now;
            for (int i = 0; i < 5; i++)
            {
                currentTime = currentTime.AddDays(i * -7);
                chDoanhThuTheoTuan.Series["DoanhThu"].Points.AddXY((i == 0) ? "Hiện tại" : $"{i} tuần trước", invoiceService.GetInvoicesByDayOfWeek(currentTime));
            }
        }

        private void FillTopProduct()
        {
            try
            {
                List<Product> Top5 = productService.GetTopSellers();
                string labelText = "";
                for(int i=0;i< Top5.Count; i++)
                {
                    if (i > 5)
                    {
                        break;
                    }
                    if (Top5[i] == null) {
                        labelText += $"#{i + 1}: Tạm thời chưa có\n";
                    }
                    else
                    {
                        labelText += $"#{i + 1}: {Top5[i].ProductName}\n";
                    }
                }
                lbTopSanPham.Text = labelText;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void trởVềToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
