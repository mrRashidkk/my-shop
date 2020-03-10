using System.Collections.Generic;
using MyShop.Application.Products;
using MyShop.Domain.Infrastructure;

namespace MyShop.Application.Cart
{
    [Service]
    public class GetCart
    {
        private ISessionManager _sessionManager;
        private readonly IProductManager _productManager;

        public GetCart(ISessionManager sessionManager, IProductManager productManager)
        {
            _sessionManager = sessionManager;
            _productManager = productManager;
        }

        public class Response
        {
            public string Name { get; set; }
            public string Value { get; set; }
            public decimal RealValue { get; set; }
            public int StockId { get; set; }
            public int Qty { get; set; }
            public string ImageName { get; set; }
        }

        public  IEnumerable<Response> Do()
        {
            return _sessionManager.GetCart(x => new Response
            {
                Name = x.ProductName,
                Value = x.Value.GetValueString(),
                RealValue = x.Value,
                StockId = x.StockId,
                Qty = x.Qty,
                ImageName = x.ImageName
            });
        }
    }
}
