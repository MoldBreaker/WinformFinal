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
using System.Xml.Linq;

namespace Forms
{
    public partial class frmKhachHang : Form
    {
        public User user = null;
        private TableService tableService = new TableService();
        private CardService cardService = new CardService();
        private ProductService productService = new ProductService();
        private ProductCategoryService productCategoryService = new ProductCategoryService();
        private InvoiceService invoiceService = new InvoiceService();
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

        public frmKhachHang()
        {
            InitializeComponent();
        }

        private void frmKhachHang_Load(object sender, EventArgs e)
        {
            if (user == null)
            {
                MessageBox.Show("Vui lòng đăng nhập trước");
                this.Close();
                return;
            }
            List<Table> tables = tableService.GetAllTables();
            List<Product> products = productService.GetAllProducts();
            List<ProductCategory> categories = productCategoryService.GetAllCategories();

            FillFLPTables(tables);
            FillFLPSanPham(products);
            PrintPromoInfo();
            CalcTotal();
            FillComboBoxTheThoai(categories);
            FillLocTheoGia();

        }

        private void FillComboBoxTheThoai(List<ProductCategory> categories)
        {
            ProductCategory newCategory = new ProductCategory();
            newCategory.CategoryId = 0;
            newCategory.CategoryName = "Tất cả";
            categories.Add(newCategory);

            cbbTheLoai.DataSource = categories;
            cbbTheLoai.DisplayMember = "CategoryName";
            cbbTheLoai.ValueMember = "CategoryId";

            cbbTheLoai.SelectedValue = 0;
        }

        private void PrintPromoInfo()
        {
            StringBuilder sb = new StringBuilder();
            foreach (var kvp in GiamGia)
            {
                sb.Append($"Với mỗi hóa đơn từ {kvp.Value} trở lên sẽ được giảm {kvp.Key}%\n");
            }
            lbThongTinKhuyenMai.Text = sb.ToString();
        }

        private void FillFLPTables(List<Table> tables)
        {
            flpBan.Controls.Clear();
            for (int i = 0; i < tables.Count; i++) {
                
                Button btn = new System.Windows.Forms.Button();
                btn.Location = new System.Drawing.Point(3, 3);
                btn.Name = tables[i].TableId.ToString();
                btn.Size = new System.Drawing.Size(40, 40);
                btn.TabIndex = 0;
                btn.Text = tables[i].TableName;
                btn.UseVisualStyleBackColor = true;
                btn.Click += new System.EventHandler(this.table_Click);
                btn.Tag = tables[i];
                btn.BackColor = System.Drawing.Color.FromArgb(255, 224, 192);
                flpBan.Controls.Add(btn);
                
                
            }
        }

        private void table_Click(object sender, EventArgs e)
        {
            Button btn = (Button)sender;
            Table table = (Table)btn.Tag;
            txtMaban.Text = table.TableId.ToString();
            txtTenBan.Text = table.TableName;
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
                panel.Size = new System.Drawing.Size(82, 80);
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
                Product product = (Product)panel.Tag;
                txtMaSP.Text = product.ProductId.ToString();
                txtTenSP.Text = product.ProductName;
                txtGia.Text = product.SellPrice.ToString();
                txtMoTa.Text = product.Description;
                txtSoLuong.Text = 1.ToString();
            }
            catch
            {
                PictureBox pictureBox = (PictureBox)sender;
                Product product = (Product)pictureBox.Tag;
                txtMaSP.Text = product.ProductId.ToString();
                txtTenSP.Text = product.ProductName;
                txtGia.Text = product.SellPrice.ToString();
                txtMoTa.Text = product.Description;
                txtSoLuong.Text = 1.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string ID = txtMaSP.Text;
                string SoLuongStr = txtSoLuong.Text;
                int SoLuong;
                int index = GetIndex(ID);
                Product product = productService.GetProductById(int.Parse(ID));

                if (!int.TryParse(SoLuongStr, out SoLuong)) {
                    throw new Exception("Số lượng không hợp lệ");
                }
                if (SoLuong < 1)
                {
                    throw new Exception("Không thể thêm khi số lượng bé hơn 1");
                }

                if (index == -1)
                {
                    int i = dgvGioHang.Rows.Add();
                    dgvGioHang.Rows[i].Cells[0].Value = ID;
                    dgvGioHang.Rows[i].Cells[1].Value = product.ProductName;
                    dgvGioHang.Rows[i].Cells[2].Value = product.SellPrice;
                    dgvGioHang.Rows[i].Cells[3].Value = SoLuong;
                    dgvGioHang.Rows[i].Cells[4].Value = SoLuong * product.SellPrice;
                } else {
                    dgvGioHang.Rows[index].Cells[0].Value = ID;
                    dgvGioHang.Rows[index].Cells[1].Value = product.ProductName;
                    dgvGioHang.Rows[index].Cells[2].Value = product.SellPrice;
                    dgvGioHang.Rows[index].Cells[3].Value = SoLuong;
                    dgvGioHang.Rows[index].Cells[4].Value = SoLuong * product.SellPrice;
                }
                MessageBox.Show("Thêm vào giỏ thành công!");
                CalcTotal();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetIndex(string ID)
        {
            for (int i = 0; i < dgvGioHang.Rows.Count; i++)
            {
                if (dgvGioHang.Rows[i].Cells[0].Value.ToString() == ID)
                {
                    return i;
                }
            }
            return -1;
        }

        private void dgvGioHang_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int index = dgvGioHang.CurrentRow.Index;
                string SoLuong = dgvGioHang.Rows[index].Cells[3].Value.ToString();
                string MaSP = dgvGioHang.Rows[index].Cells[0].Value.ToString();
                Product product = productService.GetProductById(int.Parse(MaSP));
                txtMaSP.Text = MaSP;
                txtTenSP.Text = product.ProductName;
                txtGia.Text = product.SellPrice.ToString();
                txtMoTa.Text = product.Description;
                txtSoLuong.Text = SoLuong;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xemThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan frmThongTinCaNhan = new frmThongTinCaNhan();
            frmThongTinCaNhan.user = user;
            frmThongTinCaNhan.ShowDialog();
        }

        private void đổiMậtKhẩuToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmDMK = new frmDoiMatKhau();
            Hide();
            frmDMK.user = user;
            frmDMK.ShowDialog();
            Show();
        }

        private void đăngXuấtToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if (result == DialogResult.OK)
            {
                Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show($"Bạn có chắc chắn muốn bỏ {txtTenSP.Text} ra khỏi giỏ?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    string MaSP = txtMaSP.Text;
                    int index = GetIndex(MaSP);
                    if (index == -1)
                    {
                        throw new Exception("Không tồn tại sản phẩm này trong giỏ hàng");
                    }
                    else
                    {
                        dgvGioHang.Rows.RemoveAt(index);
                        MessageBox.Show("Xóa khỏi giỏ thành công");
                        ClearInput();
                        CalcTotal();
                    }
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ClearInput()
        {
            txtMaSP.Text = "";
            txtTenSP.Text = "";
            txtGia.Text = "";
            txtMoTa.Text = "";
            txtSoLuong.Text = "";
        }

        private void CalcTotal()
        {
            int sum = 0;
            for (int i = 0; i < dgvGioHang.Rows.Count; i++)
            {
                sum += int.Parse(dgvGioHang.Rows[i].Cells[4].Value.ToString());
            }
            txtTongTien.Text = sum.ToString();
            int duocGiam = 0;
            foreach (var kvp in GiamGia)
            {
                if (sum >= kvp.Value)
                {
                    duocGiam = kvp.Key;
                }
            }
            txtGiamGia.Text = duocGiam.ToString() + "%";
            txtCanThanhToan.Text = (sum - (sum * duocGiam / 100)).ToString();
        }

        private void cbbTheLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                string valueStr = cbbTheLoai.SelectedValue.ToString();
                int value;
                if (!int.TryParse(valueStr, out value)) {
                    value = 0;
                }
                List<Product> products = new List<Product>();
                if (value == 0)
                {
                    products = productService.GetAllProducts();
                } else
                {
                    products = productService.GetProductsByCategoryId(value);
                }
                FillFLPSanPham(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if (MessageBox.Show("Bạn có chắc chắn thanh toán không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Invoice invoice = new Invoice();
                    invoice.UserId = user.UserId;
                    invoice.TotalPrice = int.Parse(txtTongTien.Text);
                    invoice.Discount = int.Parse(txtGiamGia.Text.Split('%')[0]);
                    invoice.AfterDiscount = int.Parse(txtCanThanhToan.Text);
                    if(txtMaban.Text.Trim().Length == 0)
                    {
                        invoice.TableId = null;
                    } else
                    {
                        invoice.TableId = int.Parse(txtMaban.Text);
                    }

                    List <InvoiceDetail> details = new List<InvoiceDetail>();
                    for (int i = 0; i < dgvGioHang.Rows.Count; i++)
                    {
                        InvoiceDetail detail = new InvoiceDetail();
                        detail.ProductId = int.Parse(dgvGioHang.Rows[i].Cells[0].Value.ToString());
                        detail.Quantity = int.Parse(dgvGioHang.Rows[i].Cells[3].Value.ToString());
                        detail.Price = int.Parse(dgvGioHang.Rows[i].Cells[4].Value.ToString());
                        details.Add(detail);
                    }
                    invoiceService.Checkout(invoice, details);
                    MessageBox.Show("Thanh toán thành công");
                    dgvGioHang.Rows.Clear();
                    ClearInput();
                    txtTongTien.Text = "";
                    txtGiamGia.Text = "";
                    txtCanThanhToan.Text = "";
                    txtMaban.Text = "";
                    txtTenBan.Text = "";
                    frmKhachHang_Load(sender, e);
                }
            } catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();
            products = productService.GetAllProducts().Where(p => p.ProductName.ToUpper().Contains(txtTimKiem.Text.ToUpper())).ToList();
            FillFLPSanPham(products);

        }

        public void FillLocTheoGia()
        {
            if (user == null)
            {
                MessageBox.Show("Vui lòng đăng nhập");
                this.Close();
            }
            List<ProductCategory> categories = productCategoryService.GetAllCategories();
            List<Product> products = productService.GetAllProducts();
            FillComboBoxTheThoai(categories);
            FillFLPSanPham(products);
            Dictionary<double, string> LocTheoGia = new Dictionary<double, string>();
            LocTheoGia.Add(15000, "Dưới 15K");
            LocTheoGia.Add(35000, "Dưới 35K");
            LocTheoGia.Add(70000, "Dưới 70k");
            LocTheoGia.Add(100001, "Trên 100k");
            cbbLocTheoGia.DataSource = new BindingSource(LocTheoGia, null);
            cbbLocTheoGia.DisplayMember = "Value";
            cbbLocTheoGia.ValueMember = "Key";
        }

        private void btnLocTheoGia_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = txtTimKiem.Text;
                int CategoryId = int.Parse(cbbTheLoai.SelectedValue.ToString());
                string cbbLocGiaDisplay = ((KeyValuePair<double, string>)cbbLocTheoGia.SelectedItem).Value;
                double cbbLocGiaValue = ((KeyValuePair<double, string>)cbbLocTheoGia.SelectedItem).Key;
                List<Product> products = new List<Product>();
                string valueStr = cbbTheLoai.SelectedValue.ToString();
                int value;
                if (!int.TryParse(valueStr, out value))
                {
                    value = 0;
                }
                if (cbbLocGiaDisplay.Contains("Dưới") && value == 0)
                {
                    products = productService.GetAllProducts().Where(p => p.ProductName.IndexOf(Name, 0, StringComparison.OrdinalIgnoreCase) != -1 && p.SellPrice < cbbLocGiaValue).ToList();
                }
                else if(cbbLocGiaDisplay.Contains("Trên") && value == 0)
                {
                    products = productService.GetAllProducts().Where(p => p.ProductName.IndexOf(Name, 0, StringComparison.OrdinalIgnoreCase) != -1 && p.ProductName.Contains(Name) && p.SellPrice >= cbbLocGiaValue).ToList();
                }
                else if (cbbLocGiaDisplay.Contains("Dưới"))
                {
                    products = productService.GetAllProducts().Where(p => p.ProductName.IndexOf(Name, 0, StringComparison.OrdinalIgnoreCase) != -1 && p.CategoryId == CategoryId && p.SellPrice < cbbLocGiaValue).ToList();
                }
                else
                {
                    products = productService.GetAllProducts().Where(p => p.ProductName.IndexOf(Name, 0, StringComparison.OrdinalIgnoreCase) != -1 && p.ProductName.Contains(Name) && p.CategoryId == CategoryId && p.SellPrice >= cbbLocGiaValue).ToList();
                }
                FillFLPSanPham(products);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            
        }
        private void lịchSửĐơnĐặtHàngToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLichSuDonHang frmLichSuDonHang = new FrmLichSuDonHang();
            frmLichSuDonHang.user = user;
            frmLichSuDonHang.ShowDialog();
        }

        private void btnXoaBan_Click(object sender, EventArgs e)
        {
            txtMaban.Text = string.Empty;
            txtTenBan.Text = string.Empty;

        }

        private void đăngKýThẻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Card userCard = cardService.GetCardByUserId(user.UserId);
                if(userCard != null)
                {
                    MessageBox.Show("Tài khoản này đã có thẻ rồi");
                    return;
                } else
                {
                    frmDangKiThe frmDangKiThe = new frmDangKiThe();
                    frmDangKiThe.user = user;
                    frmDangKiThe.ShowDialog();
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void xemThôngTinThẻToolStripMenuItem_Click(object sender, EventArgs e)
        {
            try
            {
                Card card = cardService.GetCardByUserId(user.UserId);
                if(card == null)
                {
                    MessageBox.Show("Vui lòng đăng kí thẻ trước");
                    return;
                } else
                {
                    frmThongTinThe frmThongTinThe = new frmThongTinThe();
                    frmThongTinThe.user = user;
                    frmThongTinThe.ShowDialog();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
