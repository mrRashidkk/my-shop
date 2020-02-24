using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;
using Microsoft.EntityFrameworkCore;
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

        public async Task<Response> Do(Request request)
        {
            var product = await _context.Products.FirstOrDefaultAsync(x => x.Id == request.Id);

            product.Description = request.Description;
            product.Name = request.Name;
            product.Value = request.Value;

            await _context.SaveChangesAsync();
            return new Response 
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                Value = product.Value
            };
        }

        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
}
