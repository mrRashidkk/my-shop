using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using MyShop.Database;
using MyShop.Domain.Models;

namespace MyShop.Application.StockAdmin
{
    public class DeleteStock
    {
        private readonly ApplicationDBContext _ctx;

        public DeleteStock(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var stock = await _ctx.Stock.FirstOrDefaultAsync(x => x.Id == id);
            _ctx.Stock.Remove(stock);

            await _ctx.SaveChangesAsync();
            return true;

        }

        
    }
}
