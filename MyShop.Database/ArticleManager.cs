using MyShop.Domain.Infrastructure;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyShop.Database
{
    public class ArticleManager : IArticleManager
    {
        public readonly ApplicationDBContext _ctx;
        public ArticleManager(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }
        public async Task CreateArticle(Article article)
        {
            _ctx.Articles.Add(article);
            await _ctx.SaveChangesAsync();
        }

        public async Task<IEnumerable<Article>> GetArticles()
        {
            return await _ctx.Articles.ToListAsync();
        }
    }
}
