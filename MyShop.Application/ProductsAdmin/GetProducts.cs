using System.Collections.Generic;
using MyShop.Domain.Infrastructure;

namespace MyShop.Application.ProductsAdmin
{
    [Service]
    public class GetProducts
    {
        private IProductManager _productManager;
        public GetProducts(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IEnumerable<ProductViewModel> Do() =>
            _productManager.GetProductsWithStock(x => new ProductViewModel
            {
                Id = x.Id,
                Name = x.Name,
                Category = x.Category,
                Value = x.Value
            });        

        public class ProductViewModel
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public decimal Value { get; set; }
        }
    }    
}
