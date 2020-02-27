using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Models;
using MyShop.Database;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace MyShop.Application.Cart
{
    public class GetCart
    {
        private ISession _session;
        private readonly ApplicationDBContext _ctx;

        public GetCart(ISession session, ApplicationDBContext ctx)
        {
            _session = session;
            _ctx = ctx;
        }

        public class Response
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public int StockId { get; set; }
            public int Qty { get; set; }
        }

        public  IEnumerable<Response> Do()
        {
            var stringObject = _session.GetString("cart");
            if(string.IsNullOrEmpty(stringObject))
            {
                return new List<Response>();
            }

            var cartList = JsonConvert.DeserializeObject<List<CartProduct>>(stringObject);

            return _ctx.Stock
                .Include(x => x.Product)
                .Where(x => cartList.Any(y => y.StockId == x.Id))
                .Select(x => new Response
                {
                    Name = x.Product.Name,
                    Value = $"$ {x.Product.Value.ToString("N2")}",
                    StockId = x.Id,
                    Qty = cartList.FirstOrDefault(y => y.StockId == x.Id).Qty
                })
                .ToList();
        }
    }
}
