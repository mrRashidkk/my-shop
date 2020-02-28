using System;
using System.Linq;
using System.Threading.Tasks;
using System.Collections.Generic;
using System.Text;
using Microsoft.EntityFrameworkCore;
using MyShop.Database;

namespace MyShop.Application.Products
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
            return await _ctx.Products
                .Include(x => x.Stock)
                .Select(x => new ProductViewModel
                {
                    Name = x.Name,
                    Description = x.Description,
                    Value = $"${x.Value.ToString("N2")}",
                    StockCount = x.Stock.Sum(y => y.Qty)
                }).ToListAsync();
        }

        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public int StockCount { get; set; }
        }
    }    
}
