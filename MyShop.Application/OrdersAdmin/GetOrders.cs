using MyShop.Domain.Enums;
using System.Collections.Generic;

using MyShop.Domain.Infrastructure;

namespace MyShop.Application.OrdersAdmin
{
    public class GetOrders
    {
        private readonly IOrderManager _orderManager;

        public GetOrders(IOrderManager orderManager)
        {
            _orderManager = orderManager;
        }

        public class Response
        {
            public int Id { get; set; }
            public string OrderRef { get; set; }
            public string Email { get; set; }
        }

        public IEnumerable<Response> Do(int status) =>
            _orderManager.GerOrdersByStatus((OrderStatus)status, x => new Response
            {
                Id = x.Id,
                OrderRef = x.OrderRef,
                Email = x.Email
            });            
    }
}
