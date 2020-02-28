using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Application.ProductsAdmin;
using MyShop.Application.StockAdmin;
using MyShop.Database;
using Microsoft.AspNetCore.Authorization;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class ProductsController : Controller
    {
        private ApplicationDBContext _ctx;
        public ProductsController(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetProducts() => Ok(await new GetProducts(_ctx).Do());

        [HttpGet("{id}")]
        public async Task<IActionResult> GetProduct(int id) => Ok(await new GetProduct(_ctx).Do(id));

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct.Request request)
        {
            return Ok(await new CreateProduct(_ctx).Do(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            await new DeleteProduct(_ctx).Do(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct.Request request)
        {
            return Ok(await new UpdateProduct(_ctx).Do(request));
        }
    }
}