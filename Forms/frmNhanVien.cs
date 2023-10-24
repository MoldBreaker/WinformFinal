using BLL;
using DAL.Models;
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
                if(txtProductID.Text.Trim().Length == 0)
                {
                    throw new Exception("Vui lòng chọn sản phẩm trước");
                }
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
            if(txtQuantity.Text == "1")
            {
                MessageBox.Show("Không thể tiếp tục giảm");
            }
            else
            {
                txtQuantity.Text = (int.Parse(txtQuantity.Text) - 1).ToString();
            }
        }

        private void btnRemove_Click(object sender, EventArgs e)
        {
            try
            {
                 if (MessageBox.Show($"Bạn có chắc chắn muốn bỏ {txtProductName.Text} ra khỏi giỏ?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                 {
                    if(txtProductID.Text.Trim().Length == 0)
                    {
                        throw new Exception("Vui lòng chọn sản phẩm trước");
                    }
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
            if (dgvOrder.Rows.Count == 0)
            {
                MessageBox.Show("Không có sản phẩm để thanh toán.", "Thông báo", MessageBoxButtons.OK);
                return;
            }
            if (rbTable.Checked == true && string.IsNullOrEmpty(txtTableID.Text))
            {
                MessageBox.Show("Chưa chọn bàn");
                return;
            }
            using (var transaction = dBContext.Database.BeginTransaction())
            {
                try
                {
                    if (MessageBox.Show("Bạn có chắc chắn thanh toán không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                    {
                        frmTheThanhVien frmThe = new frmTheThanhVien();
                        frmThe.ShowDialog();
                        if (frmThe.ConfirmButtonClicked == true)
                        {
                            string cardNumber = frmThe.card.CardNumber;
                            int userID = (int)frmThe.card.UserId;
                            Invoice invoice = new Invoice();
                            invoice.UserId = userID;
                            if (rbTable.Checked == true && !string.IsNullOrEmpty(txtTableID.Text))
                            {
                                invoice.TableId = int.Parse(txtTableID.Text);
                            }
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
                            transaction.Commit();

                            MessageBox.Show("Thanh toán thành công");
                            dgvOrder.Rows.Clear();
                        }
                        else
                        {
                            MessageBox.Show("Chưa chọn khách hàng");
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    transaction.Rollback();
                }
            }
        }

        private void rbTable_CheckChanged(object sender, EventArgs e)
        {
            if(rbTable.Checked == true)
            {
                frmTable frmTable = new frmTable();
                frmTable.ShowDialog();
                txtTableID.Text = frmTable.GetTextBoxValue();
            }
        }

        private void menuTodayOrder_Click(object sender, EventArgs e)
        {
            DateTime today = DateTime.Today;
            List<Invoice> invoices = dBContext.Invoices.Where(d => d.CreatedAt == today).ToList();
            
        }
        private void menuOrder_Click(object sender, EventArgs e)
        {
            frmDonHang frmDonHang = new frmDonHang();
            frmDonHang.ShowDialog();
        }

        private void menuLogout_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }
    }
}
