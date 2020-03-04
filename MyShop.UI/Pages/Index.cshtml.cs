using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Application.Products;

namespace MyShop.UI.Pages
{
    public class IndexModel : PageModel
    {
        //[BindProperty]
        //public GetProducts.ProductViewModel Product { get; set; }

        //public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }


        public void OnGet()
        {
            //Products = getProducts.Do();
        }

        public JsonResult OnGetProducts([FromServices] GetProducts getProducts, string category, string search)
        {
            return new JsonResult(getProducts.Do(category, search));
        }
    }
}
