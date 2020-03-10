using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using MyShop.Application.ArticlesAdmin;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]    
    public class ArticleController : Controller
    {
        private IHostingEnvironment _env;
        private const string _savePath = "images\\articles";
        public ArticleController(IHostingEnvironment env)
        {
            _env = env;
        }

        [Authorize(Policy = "Admin")]
        [HttpPost("CreateArticle")]
        public async Task<IActionResult> CreateArticle([FromServices] CreateArticle createArticle)
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

            await createArticle.Do(new CreateArticle.Request
            {
                Title = form["title"],
                Preview = form["preview"],
                Text = form["text"],
                ImageName = fileName
            });

            return Ok();
        }
        [HttpGet]
        public async Task<IActionResult> GetArticles([FromServices] GetArticles getArticles)
        {
            return Ok(await getArticles.Do());
        }
        public IActionResult Index()
        {
            return View();
        }        
    }
}