using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using MyShop.Database;
using MyShop.Domain.Models;

namespace MyShop.Application.StockAdmin
{
    public class CreateStock
    {
        private readonly ApplicationDBContext _ctx;

        public CreateStock(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<Response> Do(Request request)
        {
            var stock = new Stock
            {
                Description = request.Description,
                Qty = request.Qty,
                ProductId = request.ProductId
            };
            _ctx.Stocks.Add(stock);
            await _ctx.SaveChangesAsync();

            return new Response
            {
                Id = stock.Id,
                Description = stock.Description,
                Qty = stock.Qty
            };
        }

        public class Request
        {
            public string Description { get; set; }
            public int Qty { get; set; }
            public int ProductId { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Description { get; set; }
            public int Qty { get; set; }
        }
    }
}
