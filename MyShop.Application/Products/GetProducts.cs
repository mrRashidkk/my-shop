using System.Linq;
using System.Collections.Generic;
using MyShop.Domain.Infrastructure;
using MyShop.Domain.Models;
using System;
using System.Linq.Expressions;

namespace MyShop.Application.Products
{
    [Service]
    public class GetProducts
    {
        private readonly IProductManager _productManager;
        public GetProducts(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public IEnumerable<ProductViewModel> Do(string category, string search) =>
            _productManager.GetProductsWithStock(category, search, x => new ProductViewModel
            {
                Name = x.Name,
                Description = x.Description,
                Value = x.Value.GetValueString(),
                StockCount = x.Stock.Sum(y => y.Qty)
            });
        
        public class ProductViewModel
        {
            public string Name { get; set; }
            public string Description { get; set; }
            public string Value { get; set; }
            public int StockCount { get; set; }
        }
    }    
}
