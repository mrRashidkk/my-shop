using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Database;
using MyShop.Application.Products;

namespace MyShop.UI.Pages
{
    public class ProductModel : PageModel
    {
        private readonly ApplicationDBContext _ctx;
        public GetProduct.ProductViewModel Product { get; set; }
        public ProductModel(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }


        public async Task<IActionResult> OnGet(string name)
        {
            Product = await new GetProduct(_ctx).Do(name.Replace("-", " "));

            if (Product == null)
            {
                return RedirectToPage("Index");
            }
            return Page();
        }
    }
}
