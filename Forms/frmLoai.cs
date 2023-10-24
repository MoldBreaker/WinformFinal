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
    public partial class frmLoai : Form
    {
        private ProductCategoryService productCategoryService = new ProductCategoryService();
        public frmLoai()
        {
            InitializeComponent();
        }

        private void frmLoai_Load(object sender, EventArgs e)
        {
            List<ProductCategory> categories = productCategoryService.GetAllCategories();
            FillDGV(categories);
        }

        private void FillDGV(List<ProductCategory> categories)
        {
            dgvListLoai.Rows.Clear();
            for(int i = 0; i < categories.Count; i++)
            {
                int index = dgvListLoai.Rows.Add();
                dgvListLoai.Rows[index].Cells[0].Value = categories[i].CategoryId;
                dgvListLoai.Rows[index].Cells[1].Value = categories[i].CategoryName;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {
                string CategoryName = txtTenLoai.Text;
                ProductCategory pc = new ProductCategory();
                pc.CategoryName = CategoryName;
                productCategoryService.AddCategory(pc);
                List<ProductCategory> categories = productCategoryService.GetAllCategories();
                FillDGV(categories);
                MessageBox.Show("Thêm thành công");
                txtTenLoai.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            try
            {
                if(txtMaLoai.Text.Length == 0)
                {
                    throw new Exception("Vui lòng chọn loại trước");
                }
                int CategoryId = int.Parse(txtMaLoai.Text);
                string CategoryName = txtTenLoai.Text;
                ProductCategory pc = new ProductCategory();
                pc.CategoryId = CategoryId;
                pc.CategoryName = CategoryName;
                productCategoryService.UpdateCategory(pc);
                List<ProductCategory> categories = productCategoryService.GetAllCategories();
                FillDGV(categories);
                MessageBox.Show("Cập nhật thành công");
                txtMaLoai.Text = string.Empty;
                txtTenLoai.Text = string.Empty;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if(MessageBox.Show("Bạn có chắc chắn muốn xoá thể loại này không? Lưu ý các sản phẩm hiện có thuộc thể loại này sẽ bị xoá?", "Cảnh Báo", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn xóa?", "Thông Báo", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (result == DialogResult.OK)
                try
                {
                    if(txtMaLoai.Text.Length == 0)
                        {
                            throw new Exception("Vui lòng chọn loại trước");
                        }
                    int CategoryId = int.Parse(txtMaLoai.Text);
                    productCategoryService.DeleteCategory(CategoryId);
                    List<ProductCategory> categories = productCategoryService.GetAllCategories();
                    FillDGV(categories);
                        MessageBox.Show("Xóa thành công");
                        txtMaLoai.Text = string.Empty;
                        txtTenLoai.Text= string.Empty;
                }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);

                    }
            }
            
        }

        private void dgvListLoai_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int index = dgvListLoai.CurrentRow.Index;
            txtMaLoai.Text = dgvListLoai.Rows[index].Cells[0].Value.ToString();
            txtTenLoai.Text = dgvListLoai.Rows[index].Cells[1].Value.ToString();
        }

    }
}
