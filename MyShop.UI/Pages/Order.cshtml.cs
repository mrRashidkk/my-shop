using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using MyShop.Application.Orders;

namespace MyShop.UI.Pages
{
    public class OrderModel : PageModel
    {
        public GetOrder.Response Order { get; set; }
        

        public void OnGet([FromServices] GetOrder getOrder, string reference)
        {
            Order = getOrder.Do(reference);
        }
    }
}
