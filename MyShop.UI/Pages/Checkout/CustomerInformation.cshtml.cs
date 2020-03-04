using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Application.Cart;

namespace MyShop.UI.Pages.Checkout
{
    public class CustomerInformationModel : PageModel
    {
        private readonly IHostingEnvironment _env;
        [BindProperty]
        public AddCustomerInformation.Request CustomerInformation { get; set; }
        public CustomerInformationModel(IHostingEnvironment env)
        {
            _env = env;
        }        
        public IActionResult OnGet([FromServices] GetCustomerInformation getCustomerInformation)
        {
            var information = getCustomerInformation.Do();

            if(information == null)
            {
                //if(_env.IsDevelopment())
                //{
                //    CustomerInformation = new AddCustomerInformation.Request
                //    {
                //        FirstName = "A",
                //        LastName = "A",
                //        Email = "A@a.com",
                //        PhoneNumber = "111",
                //        Address1 = "A",
                //        Address2 = "A",
                //        City = "A",
                //        PostCode = "A"
                //    };
                //}
                return Page();
            }
            else
            {
                return RedirectToPage("/Checkout/Payment");
            }
        }

        public IActionResult OnPost([FromServices] AddCustomerInformation addCustomerInformation)
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            addCustomerInformation.Do(CustomerInformation);

            return RedirectToPage("/Checkout/Payment");
        }
    }
}
