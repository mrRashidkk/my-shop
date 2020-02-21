using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Database;
using MyShop.Domain.Models;

namespace MyShop.Application.ProductsAdmin
{
    public class DeleteProduct
    {
        private ApplicationDBContext _context;
        public DeleteProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task Do(int id)
        {
            var Product = await _context.Products.FirstOrDefaultAsync(x => x.Id == id);
            _context.Products.Remove(Product);
            await _context.SaveChangesAsync();
        } 
    }
}
