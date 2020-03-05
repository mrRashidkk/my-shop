using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyShop.Application.ProductsAdmin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class ProductsController : Controller
    {
        private IHostingEnvironment _env;
        private const string _savePath = "images\\products";
        public ProductsController(IHostingEnvironment env)
        {
            _env = env;
        }

        [HttpGet]
        public IActionResult GetProducts([FromServices] GetProducts getProducts) => 
            Ok(getProducts.Do());

        [HttpGet("{id}")]
        public IActionResult GetProduct([FromServices] GetProduct getProduct, int id) =>
            Ok(getProduct.Do(id));

        [HttpPost]
        public async Task<IActionResult> CreateProduct([FromServices] CreateProduct createProduct)
        {
            var form = HttpContext.Request.Form;
            if (form.Files.Count < 1)
            {
                return BadRequest();
            }

            var imageFile = form.Files[0];
            var webRoot = _env.WebRootPath;
            var fileName = Guid.NewGuid().ToString() + imageFile.FileName.Substring(imageFile.FileName.IndexOf('.'));
            var filePath = System.IO.Path.Combine(webRoot, _savePath, fileName);

            using (FileStream fileStream = new FileStream(filePath, FileMode.Create))
            {
                await imageFile.CopyToAsync(fileStream);
            }
            
            return Ok(await createProduct.Do(new CreateProduct.Request
            {
                Name = form["name"],
                Description = form["description"],
                Value = decimal.Parse(form["value"]),
                Category = form["category"],
                ImageName = fileName
            }));
        }
            

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteProduct([FromServices] DeleteProduct deleteProduct, int id) =>
            Ok(await deleteProduct.Do(id));        

        [HttpPut]
        public async Task<IActionResult> UpdateProduct([FromServices] UpdateProduct updateProduct, [FromBody] UpdateProduct.Request request) =>
            Ok(await updateProduct.Do(request));
        
    }
}