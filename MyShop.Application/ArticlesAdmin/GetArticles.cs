using MyShop.Domain.Infrastructure;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Application.ArticlesAdmin
{
    [Service]
    public class GetArticles
    {
        private readonly IArticleManager _articleManager;

        public GetArticles(IArticleManager articleManager)
        {
            _articleManager = articleManager;
        }

        public async Task<IEnumerable<Article>> Do()
        {
            return await _articleManager.GetArticles();
        }
    }
}
