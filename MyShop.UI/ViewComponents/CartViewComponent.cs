﻿using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Cart;
using MyShop.Database;
using System.Linq;

namespace MyShop.UI.ViewComponents
{
    public class CartViewComponent : ViewComponent
    {
        private GetCart _getCart;

        public CartViewComponent(GetCart getCart)
        {
            _getCart = getCart;
        }
        public IViewComponentResult Invoke(string view = "Default")
        {
            if (view == "Small")
            {
                var totalValue = _getCart.Do().Sum(x => x.RealValue * x.Qty);
                return View(view, $"${totalValue}");
            }
            return View(view, _getCart.Do());
        }
    }
}
