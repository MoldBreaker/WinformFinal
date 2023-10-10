using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductCategoryService : AbstractService
    {
        public List<ProductCategory> GetAllCategories()
        {
            return ProductCategoryDAL.GetAllCategories();
        }

        public ProductCategory GetCategoryById(int id)
        {
            return ProductCategoryDAL.GetCategoryById(id);
        }

        public void AddCategory(ProductCategory category)
        {
            if(category.CategoryName.Trim().Length == 0)
            {
                throw new Exception("Tên Loại không được để trống");
            }

            ProductCategoryDAL.AddCategory(category);
        }

        public void UpdateCategory(ProductCategory category)
        {
            if (category.CategoryName.Trim().Length == 0)
            {
                throw new Exception("Tên Loại không được để trống");
            }

            ProductCategory pc = ProductCategoryDAL.GetCategoryById(category.CategoryId);
            if (pc == null)
            {
                throw new Exception("Không tồn tại loại sản phẩm có mã này");
            }
            ProductCategoryDAL.UpdateCategory(category);
        }   

        public void DeleteCategory(int id)
        {
            ProductCategory pc = ProductCategoryDAL.GetCategoryById(id);
            if (pc == null)
            {
                throw new Exception("Không tồn tại loại sản phẩm có mã này");
            }
            List<Product> products = ProductDAL.GetAllProducts();
            for(int i = 0; i < products.Count; i++)
            {
                if (products[i].CategoryId == id)
                {
                    ProductDAL.DeleteProduct(products[i].ProductId);
                }
            }
            ProductCategoryDAL.RemoveCategory(pc);
        }

    }
}
