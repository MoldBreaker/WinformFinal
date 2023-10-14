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
    public partial class frmKhachHang : Form
    {
        public User user = null;
        private TableService tableService = new TableService();
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
            if(user == null)
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
            for (int i=0; i < tables.Count; i++){
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
            Button button = (Button)sender;
            Table table = (Table)button.Tag;
            MessageBox.Show(table.TableId.ToString());
        }

        private void FillFLPSanPham(List<Product> products)
        {
            flpSanPham.Controls.Clear();
            for(int i=0;i< products.Count; i++)
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

                if(!int.TryParse(SoLuongStr, out SoLuong)){
                    throw new Exception("Số lượng không hợp lệ");
                }
                if(SoLuong < 1)
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
                CalcTotal();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private int GetIndex(string ID)
        {
            for(int i=0;i<dgvGioHang.Rows.Count;i++)
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
                this.Close();
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show($"Bạn có chắc chắn muốn bỏ {txtTenSP.Text} ra khỏi giỏ?", "Thông Báo", MessageBoxButtons.YesNo) == DialogResult.Yes)
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
                        CalcTotal();
                    }
                }
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void CalcTotal()
        {
            int sum = 0;
            for(int i = 0; i < dgvGioHang.Rows.Count; i++)
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
                if(!int.TryParse(valueStr, out value)){
                    value = 0;
                }
                List<Product> products = new List<Product>();
                if(value == 0)
                {
                    products = productService.GetAllProducts();
                } else
                {
                    products = productService.GetProductsByCategoryId(value);
                }
                FillFLPSanPham(products);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnThanhToan_Click(object sender, EventArgs e)
        {
            try
            {
                if(MessageBox.Show("Bạn có chắc chắn thanh toán không?", "Thông báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
                {
                    Invoice invoice = new Invoice();
                    invoice.UserId = user.UserId;
                    invoice.TableId = null;
                    invoice.TotalPrice = int.Parse(txtTongTien.Text);
                    invoice.Discount = int.Parse(txtGiamGia.Text.Split('%')[0]);
                    invoice.AfterDiscount = int.Parse(txtCanThanhToan.Text);

                    List<InvoiceDetail> details = new List<InvoiceDetail>();
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
                }
            }catch(Exception ex)
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
    }
}
