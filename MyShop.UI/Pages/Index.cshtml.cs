using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.Application.Products;
using MyShop.Database;

namespace MyShop.UI.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ApplicationDBContext _ctx;

        public IndexModel(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        [BindProperty]
        public GetProducts.ProductViewModel Product { get; set; }

        public IEnumerable<GetProducts.ProductViewModel> Products { get; set; }
        

        public async Task OnGet()
        {
            Products = await new GetProducts(_ctx).Do();
        }

        //public async Task<IActionResult> OnPost()
        //{
        //    await new CreateProduct(_ctx).Do(Product);
        //    return RedirectToPage("Index");
        //}
    }
}
