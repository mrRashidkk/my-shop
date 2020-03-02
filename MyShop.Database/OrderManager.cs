using Microsoft.EntityFrameworkCore;
using MyShop.Domain.Enums;
using MyShop.Domain.Infrastructure;
using MyShop.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyShop.Database
{
    public class OrderManager : IOrderManager
    {
        public readonly ApplicationDBContext _ctx;
        public OrderManager(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }                

        public Task<int> CreateOrder(Order order)
        {
            _ctx.Orders.Add(order);

            return _ctx.SaveChangesAsync();
        }

        private TResult GetOrder<TResult>(Func<Order, bool> condition, Func<Order, TResult> selector)
        {
            return _ctx.Orders
                .Where(x => condition(x))
                .Include(x => x.OrderStocks)
                    .ThenInclude(x => x.Stock)
                        .ThenInclude(x => x.Product)
                .Select(selector)
                .FirstOrDefault();
        }

        public TResult GetOrderById<TResult>(int id, Func<Order, TResult> selector) =>
            GetOrder(order => order.Id == id, selector);

        public TResult GetOrderByReference<TResult>(string reference, Func<Order, TResult> selector) =>
            GetOrder(order => order.OrderRef == reference, selector);

        public bool OrderReferenceExists(string reference) =>
                _ctx.Orders.Any(x => x.OrderRef == reference);

        public IEnumerable<TResult> GerOrdersByStatus<TResult>(OrderStatus status, Func<Order, TResult> selector) =>
            _ctx.Orders
                .Where(x => x.Status == status)
                .Select(selector)
                .ToList();

        public Task<int> AdvanceOrder(int id)
        {
            _ctx.Orders.FirstOrDefault(x => x.Id == id).Status++;

            return _ctx.SaveChangesAsync();
        }
    }
}
