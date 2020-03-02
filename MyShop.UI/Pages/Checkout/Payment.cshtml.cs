using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MyShop.Application.Cart;
using MyShop.Application.Orders;

namespace MyShop.UI.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
        public string PublicKey { get; }

        public PaymentModel(IConfiguration config)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
        }
        

        public IActionResult OnGet([FromServices] GetCustomerInformation getCustomerInformation)
        {
            var information = getCustomerInformation.Do();

            if (information == null)
            {
                return RedirectToPage("/Checkout/CustomerInformation");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost([FromServices] CreateOrder createOrder, [FromServices] Application.Cart.GetOrder getOrder, string stripeEmail, string stripeToken)
        {
            var cardOrder = getOrder.Do();

            var sessionId = HttpContext.Session.Id;

            await createOrder.Do(new CreateOrder.Request
            {
                SessionId = sessionId,
                FirstName = cardOrder.CustomerInformation.FirstName,
                LastName = cardOrder.CustomerInformation.LastName,
                Email = cardOrder.CustomerInformation.Email,
                PhoneNumber = cardOrder.CustomerInformation.PhoneNumber,
                Address1 = cardOrder.CustomerInformation.Address1,
                Address2 = cardOrder.CustomerInformation.Address2,
                City = cardOrder.CustomerInformation.City,
                PostCode = cardOrder.CustomerInformation.PostCode,

                Stocks = cardOrder.Products.Select(x => new CreateOrder.Stock
                {
                    StockId = x.StockId,
                    Qty = x.Qty
                }).ToList()

            });

            return RedirectToPage("/Index");
        }
    }
}
