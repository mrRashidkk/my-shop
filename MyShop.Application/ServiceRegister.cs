using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Http;
using MyShop.Application.OrdersAdmin;
using MyShop.Application.UsersAdmin;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection self)
        {
            self.AddTransient<GetOrder>();
            self.AddTransient<GetOrders>();
            self.AddTransient<UpdateOrder>();

            self.AddTransient<CreateUser>();
            return self;
        }
    }
}
