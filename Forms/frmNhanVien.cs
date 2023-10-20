using BLL;
using DAL.Models;
using NPOI.SS.UserModel;
using NPOI.XSSF.UserModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Forms
{
    public partial class frmNhanVien : Form
    {
        public User user = null;
        public Product selectedProduct;
        public Card card;
        private ProductService productService = new ProductService();
        private InvoiceService invoiceService = new InvoiceService();
        DBContext dBContext;
        private Dictionary<int, int> GiamGia = new Dictionary<int, int>() //Trên 100k giảm 10%, ...
        {
            {
                5, 100000
            },
            {
                10, 200000
            },
            {
                15, 300000
            }
        };
        public frmNhanVien()
        {
            InitializeComponent();
            dBContext = new DBContext();
        }

        private void frmNhanVien_Load(object sender, EventArgs e)
        {
            if(user == null)
            {
                MessageBox.Show("Vui lòng đăng nhập");
                this.Close();
            }
            List<Product> products = productService.GetAllProducts();
            FillFLPSanPham(products);
            txtQuantity.Text = "0";
            btnPlus.Enabled = false;
            btnMinus.Enabled = false;
        }

        private void menuAccDetail_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan accDetail = new frmThongTinCaNhan();
            accDetail.user = user;
            accDetail.ShowDialog();
        }

        private void menuChangePassword_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau chgPass = new frmDoiMatKhau();
            Hide();
            chgPass.user = user;
            chgPass.ShowDialog();
            Show();
        }

        private void menuOrder_Click(object sender, EventArgs e)
        {

        }

        private void FillFLPSanPham(List<Product> products)
        {
            flpSanPham.Controls.Clear();
            for (int i = 0; i < products.Count; i++)
            {
                Panel panel = new System.Windows.Forms.Panel();
                PictureBox pictureBox = new System.Windows.Forms.PictureBox();
                Label labelName = new System.Windows.Forms.Label();
                Label labelPrice = new System.Windows.Forms.Label();
                

                panel.Controls.Add(labelPrice);
                panel.Controls.Add(labelName);
                panel.Controls.Add(pictureBox);
                panel.Location = new System.Drawing.Point(3, 3);
                panel.Name = "panel" + products[i].ProductId.ToString();
                panel.Size = new System.Drawing.Size(70, 80);
                panel.Click += new System.EventHandler(this.product_Click);


                if (products[i].Image != null)
                {
                    pictureBox.ImageLocation = products[i].Image;
                }
                else
                {
                    pictureBox.Image = global::Forms.Properties.Resources.Xicon;
                }
                pictureBox.Location = new System.Drawing.Point(4, 4);
                pictureBox.Name = "PictureBox" + products[i].ProductId.ToString();
                pictureBox.Size = new System.Drawing.Size(70, 50);
                pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
                pictureBox.TabIndex = 0;
                pictureBox.TabStop = false;
                pictureBox.Click += new System.EventHandler(this.product_Click);
                // 
                // label15
                // 
                labelName.AutoSize = true;
                labelName.Location = new System.Drawing.Point(0, 60);
                labelName.Name = "LabelName" + products[i].ToString();
                labelName.Size = new System.Drawing.Size(0, 16);
                labelName.TabIndex = 1;
                labelName.Text = products[i].ProductName;
                // 
                // label16
                // 
                labelPrice.AutoSize = true;
                labelPrice.Location = new System.Drawing.Point(0, 40);
                labelPrice.Name = "LabelPrice" + products[i].ToString();
                labelPrice.Size = new System.Drawing.Size(0, 16);
                labelPrice.TabIndex = 2;
                labelPrice.Text = products[i].SellPrice.ToString();

                pictureBox.Tag = products[i];
                panel.Tag = products[i];
                flpSanPham.Controls.Add(panel);
            }
        }

        private void product_Click(object sender, EventArgs e)
        {
            try
            {
                Panel panel = (Panel)sender;
                selectedProduct = (Product)panel.Tag;
                txtQuantity.Text = "1";
                btnPlus.Enabled = true;
                btnMinus.Enabled = true;
                txtProductID.Text = selectedProduct.ProductId.ToString();
                txtProductName.Text = selectedProduct.ProductName;
                txtSellPrice.Text = selectedProduct.SellPrice.ToString();
            }
            catch
            {
                PictureBox pictureBox = (PictureBox)sender;
                selectedProduct = (Product)pictureBox.Tag;
                txtQuantity.Text = "1";
                btnPlus.Enabled = true;
                btnMinus.Enabled = true;
                txtProductID.Text = selectedProduct.ProductId.ToString();
                txtProductName.Text = selectedProduct.ProductName;
                txtSellPrice.Text = selectedProduct.SellPrice.ToString();
            }
        }

        private int GetIndex(int ID)
        {
            for (int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                if ((int)dgvOrder.Rows[i].Cells[0].Value == ID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Product product = productService.GetProductById(selectedProduct.ProductId);
                int quantity = int.Parse(txtQuantity.Text);
                int index = GetIndex(selectedProduct.ProductId);
                if (index == -1)
                {
                    int i = dgvOrder.Rows.Add();
                    dgvOrder.Rows[i].Cells[0].Value = product.ProductId;
                    dgvOrder.Rows[i].Cells[1].Value = product.ProductName;
                    dgvOrder.Rows[i].Cells[2].Value = product.SellPrice;
                    dgvOrder.Rows[i].Cells[3].Value = quantity;
                    dgvOrder.Rows[i].Cells[4].Value = quantity * product.SellPrice;
                }
                else
                {
                    dgvOrder.Rows[index].Cells[0].Value = product.ProductId;
                    dgvOrder.Rows[index].Cells[1].Value = product.ProductName;
                    dgvOrder.Rows[index].Cells[2].Value = product.SellPrice;
                    dgvOrder.Rows[index].Cells[3].Value = quantity;
                    dgvOrder.Rows[index].Cells[4].Value = quantity * product.SellPrice;
                }
                CalcTotal();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CalcTotal()
        {
            int sum = 0;
            for (int i = 0; i < dgvOrder.Rows.Count; i++)
            {
                sum += int.Parse(dgvOrder.Rows[i].Cells[4].Value.ToString());
            }
            txtTotal.Text = sum.ToString();
            int duocGiam = 0;
            foreach (var kvp in GiamGia)
            {
                if (sum >= kvp.Value)
                {
                    duocGiam = kvp.Key;
                }
            }
            txtDiscount.Text = duocGiam.ToString() + "%";
            txtAfterDiscount.Text = (sum - (sum * duocGiam / 100)).ToString();
        }

        private void btnPlus_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = (int.Parse(txtQuantity.Text) + 1).ToString();
        }

        private void btnMinus_Click(object sender, EventArgs e)
        {
            txtQuantity.Text = (int.Parse(txtQuantity.Text) - 1).ToString();
            if(txtQuantity.Text == "1")
            {
                MessageBox.Show("Không thể tiếp tục giảm");
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                 if (MessageBox.Show($"Bạn có chắc chắn muốn bỏ {txtProductName.Text} ra khỏi giỏ?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                    int index = GetIndex(int.Parse(txtProductID.Text));
                    if (index == -1)
                     {
                        throw new Exception("Không tồn tại sản phẩm này trong giỏ hàng");
                     }
                     else
                     {
                         dgvOrder.Rows.RemoveAt(index);
                         MessageBox.Show("Xóa khỏi giỏ thành công");
                         CalcTotal();
                     }
                 } 
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvOrder_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvOrder.CurrentRow.Index;
                int Quantity = (int)dgvOrder.Rows[index].Cells[3].Value;
                int ID = (int)dgvOrder.Rows[index].Cells[0].Value;
                Product product = productService.GetProductById(ID);
                txtProductID.Text = ID.ToString();
                txtProductName.Text = product.ProductName;
                txtQuantity.Text = Quantity.ToString();
                txtSellPrice.Text = product.SellPrice.ToString();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void btnPay_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn thanh toán không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    frmTheThanhVien frmThe = new frmTheThanhVien();
                    frmThe.ShowDialog();
                    string cardNumber = frmThe.card.CardNumber;
                    int userID = (int)frmThe.card.UserId;
                    int point = (int)frmThe.card.Point;
                    Invoice invoice = new Invoice();
                    invoice.UserId = userID;
                    invoice.TableId = null;
                    invoice.TotalPrice = int.Parse(txtTotal.Text);
                    invoice.Discount = int.Parse(txtDiscount.Text.Split('%')[0]);
                    invoice.AfterDiscount = int.Parse(txtAfterDiscount.Text);
                    List<InvoiceDetail> details = new List<InvoiceDetail>();
                    for (int i = 0; i < dgvOrder.Rows.Count; i++)
                    {
                        InvoiceDetail detail = new InvoiceDetail();
                        detail.ProductId = int.Parse(dgvOrder.Rows[i].Cells[0].Value.ToString());
                        detail.Quantity = int.Parse(dgvOrder.Rows[i].Cells[3].Value.ToString());
                        detail.Price = int.Parse(dgvOrder.Rows[i].Cells[4].Value.ToString());
                        details.Add(detail);
                    }
                    dBContext.SaveChanges();
                    invoiceService.Checkout(invoice, details);
                    MessageBox.Show("Thanh toán thành công");
                    dgvOrder.Rows.Clear();
                }
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void menuTable_Click(object sender, EventArgs e)
        {

        }

        private void menuExportFile_Click(object sender, EventArgs e)
        {
            IWorkbook workbook = new XSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Đơn hàng");
            var headers = new[] { "Mã đơn hàng", "Người đặt hàng", "Mã bàn", "Tổng cộng", "Ngày", "Giảm giá", "Sau khi giảm" };
            var headerRow = sheet.CreateRow(0);
            for (int i = 0; i < headers.Length; i++)
            {
                headerRow.CreateCell(i).SetCellValue(headers[i]);
            }
            List<Invoice> invoices = invoiceService.GetInvoicesByDate(DateTime.Today);
            for (int i = 0; i < invoices.Count; i++)
            {
                var invoice = invoices[i];
                var row = sheet.CreateRow(i + 1);
                row.CreateCell(0).SetCellValue(invoice.InvoiceId);
                row.CreateCell(1).SetCellValue(invoice.User.Username);
                row.CreateCell(2).SetCellValue((int)invoice.TableId);
                row.CreateCell(3).SetCellValue(invoice.TotalPrice);
                row.CreateCell(4).SetCellValue(invoice.CreatedAt.ToString("dd/MM/yyyy"));
                row.CreateCell(5).SetCellValue((double)invoice.Discount);
                row.CreateCell(6).SetCellValue(invoice.AfterDiscount);
            }
            string directoryPath = "D:\\cp";
            string filePath = Path.Combine(directoryPath, "Invoices.xlsx");

            // Tạo thư mục nếu nó không tồn tại
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }

            // Lưu workbook vào file Excel
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                workbook.Write(fileStream);
            }
            Process.Start("Invoices.xlsx");
            MessageBox.Show("Xuất file Excel thành công!");
        }
    }
}
