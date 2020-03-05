using MyShop.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MyShop.Domain.Infrastructure
{
    public interface IArticleManager
    {
        Task CreateArticle(Article article);
        Task<IEnumerable<Article>> GetArticles();
    }
}
