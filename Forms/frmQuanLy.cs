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
                this.Close();
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
                this.Close();
            }
            List<ProductCategory> categories = productCategoryService.GetAllCategories();
            List<Product> products = productService.GetAllProducts();
            FillComboBoxLoai(categories);
            FillDGVListProducts(products);
        }

        public void FillComboBoxLoai(List<ProductCategory> categories)
        {
            cbbLoai.DataSource = categories;
            cbbLoai.DisplayMember = "CategoryName";
            cbbLoai.ValueMember = "CategoryId";

            cbbLocTheoLoai.DataSource = categories;
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
                dgvListSanPham.Rows[index].Cells[5].Value = products[i].Description;

            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
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
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void menuStripDoiMatKhau_Click(object sender, EventArgs e)
        {
            frmDoiMatKhau frmDMK = new frmDoiMatKhau();
            Hide();
            frmDMK.ShowDialog();
            Show();
        }

      

        private void btnSua_Click(object sender, EventArgs e)
        {
            try 
            {
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
            }
            catch(Exception ex) 
            {
                MessageBox.Show(ex.Message);
            }
            
           

        }

        private void dgvListSanPham_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvListSanPham.CurrentRow.Index;
            txtMa.Text = dgvListSanPham.Rows[index].Cells[1].Value.ToString();
            cbbLoai.Text = dgvListSanPham.Rows[index].Cells[2].Value.ToString();
            txtTen.Text = dgvListSanPham.Rows[index].Cells[3].Value.ToString();
            txtGiaBan.Text = dgvListSanPham.Rows[index].Cells[4].Value.ToString();
            rtxtMoTa.Text = dgvListSanPham.Rows[index].Cells[5].Value.ToString();

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            try
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                {
                    int ProductId = int.Parse(txtMa.Text);
                    productService.DeleteProduct(ProductId);
                    List<Product> pro = productService.GetAllProducts();
                    FillDGVListProducts(pro);
                }
                
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}
