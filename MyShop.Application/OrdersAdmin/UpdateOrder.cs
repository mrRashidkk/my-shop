using MyShop.Database;
using MyShop.Domain.Enums;
using System;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace MyShop.Application.OrdersAdmin
{
    public class UpdateOrder
    {
        private readonly ApplicationDBContext _ctx;

        public UpdateOrder(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        public async Task<bool> Do(int id)
        {
            var order = _ctx.Orders.FirstOrDefault(x => x.Id == id);

            order.Status = order.Status + 1;

            return await _ctx.SaveChangesAsync() > 0;
        }
    }
}
