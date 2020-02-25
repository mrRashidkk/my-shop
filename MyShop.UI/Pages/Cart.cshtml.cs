using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Application.Cart;
using MyShop.Database;

namespace MyShop.UI.Pages
{
    public class CartModel : PageModel
    {
        private readonly ApplicationDBContext _ctx;
        public IEnumerable<GetCart.Response> Cart { get; set; }

        public CartModel(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        
        public IActionResult OnGet()
        {
            Cart = new GetCart(HttpContext.Session, _ctx).Do();

            return Page();
        }
    }
}
