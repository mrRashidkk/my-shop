using MyShop.Domain.Models;
using System;
using System.Collections.Generic;

namespace MyShop.Domain.Infrastructure
{
    public interface ISessionManager
    {
        string GetId();
        void AddProduct(CartProduct cartProduct);
        void RemoveProduct(int stockId, int qty);
        IEnumerable<TResult> GetCart<TResult>(Func<CartProduct, TResult> selector);
        void ClearCart();

        void AddCustomerInformation(CustomerInformation customer);
        CustomerInformation GetCustomerInformation();
    }
}
