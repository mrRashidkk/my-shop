using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyShop.Database;

namespace MyShop.Application.ProductsAdmin
{
    public class GetProduct
    {
        private readonly ApplicationDBContext _ctx;
        public GetProduct(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<ProductViewModel> Do(int id)
        {
            return await _ctx.Products.Select(x => new ProductViewModel
            {
                Id = x.Id, 
                Name = x.Name,
                Description = x.Description,
                Value = $"$ {x.Value.ToString("N2")}"
            }).FirstOrDefaultAsync(x => x.Id == id);
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
        }
    }
}
