using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Application.Cart;
using MyShop.Database;

namespace MyShop.UI.Pages.Checkout
{
    public class CustomerInformationModel : PageModel
    {
        private readonly ApplicationDBContext _ctx;
        [BindProperty]
        public AddCustomerInformation.Request CustomerInformation { get; set; }

        public CustomerInformationModel(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }
        public IActionResult OnGet()
        {
            var information = new GetCustomerInformation(HttpContext.Session).Do();

            if(information == null)
            {
                return Page();
            }
            else
            {
                return RedirectToPage("/Checkout/Payment");
            }
        }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            new AddCustomerInformation(HttpContext.Session).Do(CustomerInformation);

            return RedirectToPage("/Checkout/Payment");
        }
    }
}
