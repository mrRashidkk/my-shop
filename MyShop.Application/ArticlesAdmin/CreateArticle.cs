using MyShop.Domain.Infrastructure;
using MyShop.Domain.Models;
using System;
using System.Threading.Tasks;

namespace MyShop.Application.ArticlesAdmin
{
    [Service]
    public class CreateArticle
    {
        private readonly IArticleManager _articleManager;

        public CreateArticle(IArticleManager articleManager)
        {
            _articleManager = articleManager;
        }

        public async Task Do(CreateArticle.Request request)
        {
            var article = new Article
            {
                Title = request.Title,
                Preview = request.Preview,
                Text = request.Text,
                ImageName = request.ImageName
            };

            await _articleManager.CreateArticle(article);
        }

        public class Request
        {
            public string Title { get; set; }
            public string Preview { get; set; }
            public string Text { get; set; }
            public string ImageName { get; set; }
        }
    }
}
