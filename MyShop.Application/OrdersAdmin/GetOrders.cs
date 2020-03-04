using MyShop.Domain.Enums;
using System.Collections.Generic;
using MyShop.Domain.Infrastructure;

namespace MyShop.Application.OrdersAdmin
{
    [Service]
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
            public string FirstName { get; set; }
            public string LastName { get; set; }
            public string OrderRef { get; set; }
            public string Email { get; set; }
            public string Address1 { get; set; }
            public string PostCode { get; set; }
        }

        public IEnumerable<Response> Do(int status) =>
            _orderManager.GerOrdersByStatus((OrderStatus)status, x => new Response
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                OrderRef = x.OrderRef,
                Email = x.Email,
                Address1 = x.Address1,
                PostCode = x.PostCode
            });            
    }
}
