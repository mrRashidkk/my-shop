using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Application.Orders;
using MyShop.Database;

namespace MyShop.UI.Pages
{
    public class OrderModel : PageModel
    {
        private readonly ApplicationDBContext _ctx;
        public GetOrder.Response Order { get; set; }

        public OrderModel(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task OnGet(string reference)
        {
            Order = await new GetOrder(_ctx).Do(reference);
        }
    }
}
