using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyShop.Database;

namespace MyShop.Application.ProductsAdmin
{
    public class GetProducts
    {
        private readonly ApplicationDBContext _ctx;
        public GetProducts(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<ProductViewModel>> Do()
        {
            return await _ctx.Products.Select(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Value = x.Value
            }).ToListAsync();
        }

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public decimal Value { get; set; }
        }
    }    
}
