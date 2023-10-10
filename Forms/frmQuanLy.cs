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
    }
}
