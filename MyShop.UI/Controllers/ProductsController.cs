using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyShop.Application.ProductsAdmin;
using Microsoft.AspNetCore.Authorization;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class ProductsController : Controller
    {
        [HttpGet]
        public IActionResult GetProducts([FromServices] GetProducts getProducts) => 
            Ok(getProducts.Do());

        [HttpGet("{id}")]
        public IActionResult GetProduct([FromServices] GetProduct getProduct, int id) =>
            Ok(getProduct.Do(id));

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromServices] CreateProduct createProduct, [FromBody] CreateProduct.Request request) => 
            Ok(await createProduct.Do(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromServices] DeleteProduct deleteProduct, int id) =>
            Ok(await deleteProduct.Do(id));        

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromServices] UpdateProduct updateProduct, [FromBody] UpdateProduct.Request request) =>
            Ok(await updateProduct.Do(request));
        
    }
}