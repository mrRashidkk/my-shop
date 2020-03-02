using MyShop.Application.Cart;
using MyShop.Application.OrdersAdmin;
using MyShop.Application.UsersAdmin;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class ServiceRegister
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection self)
        {
            self.AddTransient<MyShop.Application.OrdersAdmin.GetOrder>();
            self.AddTransient<GetOrders>();
            self.AddTransient<UpdateOrder>();

            self.AddTransient<GetCart>();
            self.AddTransient<AddCustomerInformation>();
            self.AddTransient<AddToCart>();
            self.AddTransient<GetCustomerInformation>();
            self.AddTransient<MyShop.Application.Cart.GetOrder>();
            self.AddTransient<RemoveFromCart>();

            self.AddTransient<CreateUser>();

            return self;
        }
    }
}
