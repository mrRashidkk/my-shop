using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Configuration;
using MyShop.Application.Cart;
using MyShop.Application.Orders;
using MyShop.Database;
using Stripe;

namespace MyShop.UI.Pages.Checkout
{
    public class PaymentModel : PageModel
    {
        public string PublicKey { get; }

        private readonly ApplicationDBContext _ctx;

        public PaymentModel(IConfiguration config, ApplicationDBContext ctx)
        {
            PublicKey = config["Stripe:PublicKey"].ToString();
            _ctx = ctx;
        }
        

        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();

            if (information == null)
            {
                return RedirectToPage("/Checkout/CustomerInformation");
            }

            return Page();
        }

        public async Task<IActionResult> OnPost(string stripeEmail, string stripeToken)
        {
            var cardOrder = new Application.Cart.GetOrder(HttpContext.Session, _ctx).Do();

            var sessionId = HttpContext.Session.Id;

            await new CreateOrder(_ctx).Do(new CreateOrder.Request
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
