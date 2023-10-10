using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductCategoryDAL : AbstractDAL
    {
        public List<ProductCategory> GetAllCategories()
        {
            return context.ProductCategories.ToList();
        }

        public void AddCategory(ProductCategory category)
        {
            context.ProductCategories.Add(category);
            context.SaveChanges();
        }

        public void RemoveCategory(ProductCategory category)
        {
            context.ProductCategories.Remove(category);
            context.SaveChanges();
        }

        public void UpdateCategory(ProductCategory category)
        {
            ProductCategory pc = context.ProductCategories.FirstOrDefault(p =>  p.CategoryId == category.CategoryId);
            
            if (pc != null)
            {
                pc.CategoryName = category.CategoryName;
                context.SaveChanges();
            }
        }

        public ProductCategory GetCategoryById(int id) {
            return context.ProductCategories.FirstOrDefault(pc => pc.CategoryId == id);
        }
    }
}
