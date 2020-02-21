using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyShop.Database;
using MyShop.Domain.Models;

namespace MyShop.Application.ProductsAdmin
{
    public class UpdateProduct
    {
        private ApplicationDBContext _context;
        public UpdateProduct(ApplicationDBContext context)
        {
            _context = context;
        }

        public async Task Do(ProductViewModel vm)
        {
            await _context.SaveChangesAsync();
        }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
}
