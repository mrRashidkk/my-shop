using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Cart;

namespace MyShop.UI.Controllers
{
    [Route("[controller]/[action]")]
    public class CartController : Controller
    {
        [HttpPost("{stockId}")]
        public async Task<IActionResult> AddOne([FromServices] AddToCart addToCart, int stockId)
        {
            var request = new AddToCart.Request
            {
                StockId = stockId,
                Qty = 1
            };

            var success = await addToCart.Do(request);
            if (success)
            {
                return Ok("Item Added to cart");
            }
            return BadRequest("Failed to add to cart");
        }

        [HttpPost("{stockId}/{qty}")]
        public async Task<IActionResult> Remove([FromServices] RemoveFromCart removeFromCart, int stockId, int qty)
        {
            var request = new RemoveFromCart.Request
            {
                StockId = stockId,
                Qty = qty
            };

            var success = await removeFromCart.Do(request);
            if (success)
            {
                return Ok("Item removed from cart");
            }
            return BadRequest("Failed to remove from cart");
        }

        [HttpGet]
        public IActionResult GetCartComponent([FromServices] GetCart getCart)
        {
            var totalValue = getCart.Do().Sum(x => x.RealValue * x.Qty);

            return PartialView("/Views/Shared/Components/Cart/Small.cshtml", $"${totalValue}");
        }

        [HttpGet]
        public IActionResult GetCartMain([FromServices] GetCart getCart)
        {
            var cart = getCart.Do();

            return PartialView("_CartPartial", cart);
        }
    }
}