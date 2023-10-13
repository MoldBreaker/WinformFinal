using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class ProductService : AbstractService
    {
        public List<Product> GetAllProducts()
        {
            return ProductDAL.GetAllProducts();
        }

        public Product GetProductById(int id)
        {
            return ProductDAL.GetProductById(id);
        }
        public void AddProduct(Product product) 
        { 
            if(product.ProductName.Trim().Length == 0) 
            {
                throw new Exception("Tên không được để trống");
            }   
            if(product.SellPrice <= 0 || product.SellPrice > 500000)
            {
                throw new Exception("Giá không hợp lệ");
            }
            if(product.Description.Trim().Length == 0)
            {
                throw new Exception("Mô tả không được để trống");
            }
            ProductDAL.AddProduct(product);

        }

        public void UpdateProduct(Product product) 
        {
            if(product.ProductName.Trim().Length == 0)
            {
                throw new Exception("Tên không được để trống");
            } 
            if(product.SellPrice == 0)
            {
                throw new Exception("Giá không được để trống");
            }
            if(product.Description.Trim().Length == 0)
            {
                throw new Exception("Mô tả không được để trống");
            }

            Product pr = ProductDAL.GetProductById(product.ProductId);
            if(pr == null)
            {
                throw new Exception("Không tồn tại sản phẩm này");
            }
            ProductDAL.UpdateProduct(product);
        }

        public void DeleteProduct(int id)
        {
            Product pr = ProductDAL.GetProductById(id);
            if (pr == null)
            {
                throw new Exception("Không tồn tại loại sản phẩm có mã này");
            }
            List<Product> products = ProductDAL.GetAllProducts();
            for (int i = 0; i < products.Count; i++)
            {
                if (products[i].ProductId == id)
                {
                    ProductDAL.DeleteProduct(products[i].ProductId);
                }
            }
            ProductDAL.DeleteProduct(pr.ProductId);
        }

        public List<Product> GetProductsByCategoryId(int categoryId)
        {
            ProductCategory category = ProductCategoryDAL.GetCategoryById(categoryId);
            if(category == null)
            {
                throw new Exception("Không thìm thấy loại này");
            }
            return ProductDAL.GetAllProducts().Where(p => p.CategoryId == category.CategoryId).ToList();
        }
    }
}
