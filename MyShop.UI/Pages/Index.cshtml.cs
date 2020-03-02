using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Application.Products;

namespace MyShop.UI.Pages
{
    public class IndexModel : PageModel
    {
        [BindProperty]
        public GetProducts.ProductViewModel Product { get; set; }

        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
        

        public void OnGet([FromServices] GetProducts getProducts)
        {
            Products = getProducts.Do();
        }        
    }
}
