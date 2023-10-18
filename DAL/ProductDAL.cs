using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public class ProductDAL : AbstractDAL
    {
        public void DeleteProduct(int id)
        {
            Product product = context.Products.FirstOrDefault(p => p.ProductId == id);
            if (product != null)
            {
                context.Products.Remove(product);
                context.SaveChanges();
            }
        }

        public void AddProduct(Product product)
        {
            context.Products.Add(product);
            context.SaveChanges();
        }

        public List<Product> GetAllProducts()
        {
            return context.Products.ToList();
        }
        public Product GetProductById(int id)
        {
            return context.Products.FirstOrDefault(p => p.ProductId == id);
        }

        public void UpdateProduct(Product product)
        {
            Product pr = context.Products.FirstOrDefault(p => p.ProductId == product.ProductId);

            if(pr != null)
            {
                pr.ProductName = product.ProductName;
                pr.CategoryId = product.CategoryId;
                pr.SellPrice = product.SellPrice;
                pr.Image = product.Image;
                pr.Description = product.Description;
                
            }
            context.SaveChanges();
        }

        public List<Product> GetTopSeller(int num)
        {
            var topSellers = context.InvoiceDetails
                .GroupBy(d => d.ProductId)
                .Select(group => new
                {
                    ProductID = group.Key,
                    TotalQuantity = group.Sum(d => d.Quantity)
                })
                .OrderByDescending(result => result.TotalQuantity)
                .Take(num)
                .ToList();

            var topSellerProductIDs = topSellers.Select(result => result.ProductID).ToList();
            var topSellerProducts = context.Products
                .Where(p => topSellerProductIDs.Contains(p.ProductId))
                .ToList();
            topSellerProducts.Reverse();

            return topSellerProducts;
        }

    }
}
