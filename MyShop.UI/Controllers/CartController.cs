using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Cart;
using MyShop.Database;

namespace MyShop.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        private ApplicationDBContext _ctx;

        public CartController(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> AddOne(int stockId)
        {
            var request = new AddToCart.Request
            {
                StockId = stockId,
                Qty = 1
            };

            var addToCart = new AddToCart(HttpContext.Session, _ctx);

            var success = await addToCart.Do(request);
            if (success)
            {
                return Ok("Item Added to cart");
            }
            return BadRequest("Failed to add to cart");
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> RemoveOne(int stockId)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                Qty = 1
            };

            var removeFromCart = new RemoveFromCart(HttpContext.Session, _ctx);

            var success = await removeFromCart.Do(request);
            if (success)
            {
                return Ok("Item removed from cart");
            }
            return BadRequest("Failed to remove from cart");
        }

        [HttpPost("{stockId}")]
        public async Task<IActionResult> RemoveAll(int stockId)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                All = true
            };

            var removeFromCart = new RemoveFromCart(HttpContext.Session, _ctx);

            var success = await removeFromCart.Do(request);
            if (success)
            {
                return Ok("All item removed from cart");
            }
            return BadRequest("Failed to remove all items from cart");
        }
    }
}