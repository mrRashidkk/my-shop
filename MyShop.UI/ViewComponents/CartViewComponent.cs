using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Cart;
using MyShop.Database;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.UI.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private readonly ApplicationDBContext _ctx;

        public CartViewComponent(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public IViewComponentResult Invoke(string view = "Default")
        {
            if (view == "Small")
            {
                var totalValue = new GetCart(HttpContext.Session, _ctx).Do().Sum(x => x.RealValue * x.Qty);
                return View(view, $"${totalValue}");
            }
            return View(view, new GetCart(HttpContext.Session, _ctx).Do());
        }
    }
}
