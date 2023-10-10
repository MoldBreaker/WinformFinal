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
    }
}
