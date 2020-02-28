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
    public class StocksController : Controller
    {
        private ApplicationDBContext _ctx;
        public StocksController(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public async Task<IActionResult> GetStocks() => Ok(await new GetStock(_ctx).Do());

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromBody] CreateStock.Request request)
        {
            return Ok(await new CreateStock(_ctx).Do(request));
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock(int id)
        {
            await new DeleteStock(_ctx).Do(id);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStock([FromBody] UpdateStock.Request request)
        {
            return Ok(await new UpdateStock(_ctx).Do(request));
        }
    }
}