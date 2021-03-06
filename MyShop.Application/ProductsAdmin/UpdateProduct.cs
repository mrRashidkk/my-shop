﻿using System.Threading.Tasks;
using MyShop.Domain.Infrastructure;

namespace MyShop.Application.ProductsAdmin
{
    [Service]
    public class UpdateProduct
    {
        private IProductManager _productManager;
        public UpdateProduct(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public async Task<Response> Do(Request request)
        {
            var product = _productManager.GetProductById(request.Id, x => x);

            product.Description = request.Description;
            product.Category = request.Category;
            product.Name = request.Name;
            product.Value = request.Value;

            await _productManager.UpdateProduct(product);
            
            return new Response 
            {
                Id = product.Id,
                Name = product.Name, 
                Category = product.Category,
                Description = product.Description,
                Value = product.Value
            };
        }

        public class Request
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }

        public class Response
        {
            public int Id { get; set; }
            public string Name { get; set; }
            public string Category { get; set; }
            public string Description { get; set; }
            public decimal Value { get; set; }
        }
    }
}
