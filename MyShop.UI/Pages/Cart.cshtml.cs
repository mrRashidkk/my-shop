using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Application.Cart;

namespace MyShop.UI.Pages
{
    public class CartModel : PageModel
    {
        public IEnumerable<GetCart.Response> Cart { get; set; }        
        
        public IActionResult OnGet([FromServices] GetCart getCart)
        {
            Cart = getCart.Do();

            return Page();
        }
    }
}
