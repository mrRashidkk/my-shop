using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Cart;
using MyShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.UI.ViewComponents
{
    public class Cart : ViewComponent
    {
        private readonly ApplicationDBContext _ctx;

        public Cart(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IViewComponentResult Invoke(string view = "Default")
        {
            return View(view, new GetCart(HttpContext.Session, _ctx).Do());
        }
    }
}
