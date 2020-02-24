using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using MyShop.Database;
using MyShop.Domain.Models;

namespace MyShop.Application.StockAdmin
{
    public class GetStock
    {
        private readonly ApplicationDBContext _ctx;

        public GetStock(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<IEnumerable<ProductViewModel>> Do()
        {
            var stocks = await _ctx.Products
                .Include(x => x.Stock)
                .Select(x => new ProductViewModel
                { 
                    Id = x.Id,
                    Description = x.Description,
                    Stock = x.Stock.Select(y => new StockViewModel
                    {
                        Id = y.Id,
                        Description = y.Description,
                        Qty = y.Qty
                    })
                })
                .ToListAsync();

            return stocks;
        }

        public class StockViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        } 
        
        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public IEnumerable<StockViewModel> Stock { get; set; }
        }
    }
}
