using BLL;
using DAL;
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
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace Forms
{
    public partial class frmQuanLy : Form
    {
        private bool IsLogout = false;
        private ProductCategoryService productCategoryService = new ProductCategoryService();
        private ProductService productService = new ProductService();
        public User user = null;

        public frmQuanLy()
        {
            InitializeComponent();
        }

        private void mnStripDangXuat_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn đăng xuất?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning);
            if(result == DialogResult.OK)
            {
                IsLogout = true;
                Close();
            }
        }

        private void mnStripQLLoai_Click(object sender, EventArgs e)
        {
            frmLoai frmLoai = new frmLoai();
            Hide();
            frmLoai.ShowDialog();
            Show();
        }

        private void frmQuanLy_Load(object sender, EventArgs e)
        {
            if(user == null)
            {
                MessageBox.Show("Vui lòng đăng nhập");
                Close();
            }
            List<ProductCategory> categories = productCategoryService.GetAllCategories();
            List<Product> products = productService.GetAllProducts();
            FillComboBoxLoai();
            FillDGVListProducts(products);
            Dictionary<double, string> LocTheoGia = new Dictionary<double, string>();
            LocTheoGia.Add(15000, "Dưới 15K");
            LocTheoGia.Add(35000, "Dưới 35K");
            LocTheoGia.Add(70000, "Dưới 70k");
            LocTheoGia.Add(100001, "Trên 100k");
            cbbLocTheoGia.DataSource = new BindingSource(LocTheoGia, null);
            cbbLocTheoGia.DisplayMember = "Value";
            cbbLocTheoGia.ValueMember = "Key";
        }


        public void FillComboBoxLoai()
        {
            List<ProductCategory> categoriesCbbLoai = productCategoryService.GetAllCategories();
            cbbLoai.DataSource = categoriesCbbLoai;
            cbbLoai.DisplayMember = "CategoryName";
            cbbLoai.ValueMember = "CategoryId";
            List<ProductCategory> categoriesCbbLocTheoLoai = productCategoryService.GetAllCategories();
            cbbLocTheoLoai.DataSource = categoriesCbbLocTheoLoai;
            cbbLocTheoLoai.DisplayMember = "CategoryName";
            cbbLocTheoLoai.ValueMember = "CategoryId";
        }

        private void frmQuanLy_VisibleChanged(object sender, EventArgs e)
        {
            frmQuanLy_Load(sender, e);
        }

        private void FillDGVListProducts(List<Product> products)
        {
            dgvListSanPham.Rows.Clear();
            for(int i = 0; i < products.Count; i++)
            {
                int index = dgvListSanPham.Rows.Add();
                dgvListSanPham.Rows[index].Cells[0].Value = index + 1;
                dgvListSanPham.Rows[index].Cells[1].Value = products[i].ProductId;
                ProductCategory pc = productCategoryService.GetCategoryById(products[i].CategoryId);
                dgvListSanPham.Rows[index].Cells[2].Value = pc.CategoryName;
                dgvListSanPham.Rows[index].Cells[3].Value = products[i].ProductName;
                dgvListSanPham.Rows[index].Cells[4].Value = products[i].SellPrice;
                dgvListSanPham.Rows[index].Cells[5].Value = products[i].Description.ToString();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtTen.Text.Trim().Length == 0 || txtGiaBan.Text.Length == 0 || rtxtMoTa.Text.Trim().Length == 0) 
                {
                    throw new Exception("Bạn chưa điền đầy đủ thông tin");
                }
                string ProductName = txtTen.Text;
                double SellPrice = double.Parse(txtGiaBan.Text);
                string Description = rtxtMoTa.Text;
                Product product = new Product();
                product.ProductName = ProductName;
                product.Image = txtAnh.Text == "" ? null : txtAnh.Text;
                product.SellPrice = SellPrice;
                product.CategoryId = int.Parse(cbbLoai.SelectedValue.ToString());
                product.Description = Description;
                productService.AddProduct(product);
                List<Product> products = productService.GetAllProducts();
                FillDGVListProducts(products);
                MessageBox.Show("Thêm thành công");
                ClearInput();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void menuStripDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmDMK = new frmDoiMatKhau();
            Hide();
            frmDMK.user = user;
            frmDMK.ShowDialog();
            Show();
        }
        private void btnSua_Click(object sender, EventArgs e)
        {
            try 
            {
                if(txtMa.Text.Trim().Length == 0)
                {
                    throw new Exception("Vui lòng chọn sản phẩm trước");
                }
                int productId = int.Parse(txtMa.Text);
                int productCategory = int.Parse(cbbLoai.SelectedValue.ToString());
                string productName = txtTen.Text;
                double sellPrice = double.Parse(txtGiaBan.Text);
                string Description = rtxtMoTa.Text;
                Product pro = new Product();
                pro.ProductId = productId;
                pro.CategoryId = productCategory; 
                pro.ProductName = productName;
                pro.SellPrice = sellPrice;
                pro.Image = txtAnh.Text == "" ? null : txtAnh.Text;
                pro.Description = Description;
                productService.UpdateProduct(pro);
                frmQuanLy_Load(sender, e);
                MessageBox.Show("Cập nhật thành công");
                ClearInput();
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void dgvListSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvListSanPham.CurrentRow.Index;
            Product product = productService.GetProductById(int.Parse(dgvListSanPham.Rows[index].Cells[1].Value.ToString()));
            txtMa.Text = dgvListSanPham.Rows[index].Cells[1].Value.ToString();
            cbbLoai.Text = dgvListSanPham.Rows[index].Cells[2].Value.ToString();
            txtTen.Text = dgvListSanPham.Rows[index].Cells[3].Value.ToString();
            txtGiaBan.Text = dgvListSanPham.Rows[index].Cells[4].Value.ToString();
            rtxtMoTa.Text = dgvListSanPham.Rows[index].Cells[5].Value.ToString();
            txtAnh.Text = product.Image;
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    if(txtMa.Text.Trim().Length == 0)
                    {
                        throw new Exception("Vùi lòng chọn sản phẩm trước");
                    }
                    int ProductId = int.Parse(txtMa.Text);
                    productService.DeleteProduct(ProductId);
                    List<Product> pro = productService.GetAllProducts();
                    FillDGVListProducts(pro);
                    MessageBox.Show("Xóa thành công");
                    ClearInput();


                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        public void ClearInput()
        {
            txtMa.Text = string.Empty;
            txtTen.Text = string.Empty;
            txtGiaBan.Text = string.Empty;
            txtAnh.Text = string.Empty;
            rtxtMoTa.Text = string.Empty;
        }
            
        private void btnLoc_Click(object sender, EventArgs e)
        {
            try
            {
                string Name = txtTimKiem.Text;
                int CategoryId = int.Parse(cbbLocTheoLoai.SelectedValue.ToString());
                string cbbLocGiaDisplay = ((KeyValuePair<double, string>)cbbLocTheoGia.SelectedItem).Value;
                double cbbLocGiaValue = ((KeyValuePair<double, string>)cbbLocTheoGia.SelectedItem).Key;
                List<Product> products = new List<Product>();
                if (cbbLocGiaDisplay.Contains("Dưới"))
                {
                    products = productService.GetAllProducts().Where(p => p.ProductName.IndexOf(Name, 0, StringComparison.OrdinalIgnoreCase) != -1 && p.CategoryId == CategoryId && p.SellPrice < cbbLocGiaValue).ToList();
                } else
                {
                    products = productService.GetAllProducts().Where(p => p.ProductName.IndexOf(Name, 0, StringComparison.OrdinalIgnoreCase) != -1 && p.ProductName.Contains(Name) && p.CategoryId == CategoryId && p.SellPrice >= cbbLocGiaValue).ToList();
                }
                FillDGVListProducts(products);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnMacDinh_Click(object sender, EventArgs e)
        {
            frmQuanLy_Load(sender, e);
        }

        private void hóaĐơnToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyNguoiDung frmQuanLyNguoiDung = new frmQuanLyNguoiDung();
            this.Hide();
            frmQuanLyNguoiDung.ShowDialog();
            this.Show();
        }

        private void mnStripQuanLyBan_Click(object sender, EventArgs e)
        {
            frmQuanLyBan frmQLBan = new frmQuanLyBan();
            this.Hide();
            frmQLBan.ShowDialog();
            this.Show();
        }

        private void xemThôngTinToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmThongTinCaNhan frmThongTinCaNhan = new frmThongTinCaNhan();
            frmThongTinCaNhan.user = user;
            frmThongTinCaNhan.ShowDialog();
        }

        private void txtTimKiem_TextChanged(object sender, EventArgs e)
        {
            List<Product> products = new List<Product>();
            products = productService.GetAllProducts().Where(p => p.ProductName.ToUpper().Contains(txtTimKiem.Text.ToUpper())).ToList();
            FillDGVListProducts(products);
        }

        private void btnOpenfile_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Images|*.png;*.jpg;*.ico";
                if(openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtAnh.Text = openFileDialog.FileName;
                }
            }catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void thốngKêToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmQuanLyThongKe frmQuanLyThongKe = new frmQuanLyThongKe();
            this.Hide();
            frmQuanLyThongKe.ShowDialog();
            this.Show();
        }
        private void hóaĐơnToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                frmQuanLyHoaDon frmQuanLyHoaDon = new frmQuanLyHoaDon();
                frmQuanLyHoaDon.user = user;
                this.Hide();
                frmQuanLyHoaDon.ShowDialog();
                this.Show();
            }catch(Exception ex)
            {
                MessageBox.Show(ex.Message); 
            }
        }
    }
}
