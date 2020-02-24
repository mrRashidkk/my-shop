using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Application.ProductsAdmin;
using MyShop.Application.StockAdmin;
using MyShop.Database;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private ApplicationDBContext _ctx;
        public AdminController(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts() => Ok(await new GetProducts(_ctx).Do());        

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProduct(int id) => Ok(await new GetProduct(_ctx).Do(id));

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct.Request request) 
        {
            return Ok(await new CreateProduct(_ctx).Do(request));
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id) 
        {
            await new DeleteProduct(_ctx).Do(id);
            return Ok();
        }

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct.Request request) 
        {
            return Ok(await new UpdateProduct(_ctx).Do(request));
        }


        [HttpGet("stocks")]
        public async Task<IActionResult> GetStocks() => Ok(await new GetStock(_ctx).Do());
        
        [HttpPost("stocks")]
        public async Task<IActionResult> CreateStock([FromBody] CreateStock.Request request)
        {
            return Ok(await new CreateStock(_ctx).Do(request));
        }

        [HttpDelete("stocks/{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await new DeleteStock(_ctx).Do(id);
            return Ok();
        }

        [HttpPut("stocks")]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStock.Request request)
        {
            return Ok(await new UpdateStock(_ctx).Do(request));
        }
    }
}
