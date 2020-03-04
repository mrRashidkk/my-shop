using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Infrastructure;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Database
{
    public class ProductManager : IProductManager
    {
        private readonly ApplicationDBContext _ctx;  
        public ProductManager(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public Task<int> CreateProduct(Product product)
        {
            _ctx.Products.Add(product);
            return _ctx.SaveChangesAsync();
        }

        public Task<int> DeleteProduct(int id)
        {
            var product = _ctx.Products.FirstOrDefault(x => x.Id == id);
            _ctx.Products.Remove(product);

            return _ctx.SaveChangesAsync();
        }
        public Task<int> UpdateProduct(Product product)
        {
            _ctx.Products.Update(product);

            return _ctx.SaveChangesAsync();
        }


        public TResult GetProductById<TResult>(int id, Func<Product, TResult> selector)
        {
            return _ctx.Products
                .Include(x => x.Stock)
                .Where(x => x.Id == id)
                .Select(selector)
                .FirstOrDefault();
        }

        public TResult GetProductByName<TResult>(string name, Func<Product, TResult> selector)
        {
            return _ctx.Products
                .Include(x => x.Stock)
                .Where(x => x.Name == name)
                .Select(selector)
                .FirstOrDefault();
        }

        public IEnumerable<TResult> GetProductsWithStock<TResult>(Func<Product, TResult> selector)
        {
            return _ctx.Products
                .Include(x => x.Stock)
                .Select(selector)
                .ToList();
        }

        public IEnumerable<TResult> GetProductsWithStock<TResult>(string category, string search, Func<Product, TResult> selector)
        {
            var products = _ctx.Products
                .Include(x => x.Stock)
                .Where(x => x.Category == category);

            if (!string.IsNullOrEmpty(search))
            {
                products = products.Where(x => x.Name.IndexOf(search, StringComparison.InvariantCultureIgnoreCase) >= 0);
            }

            return products.Select(selector).ToList();
        }
    }
}
