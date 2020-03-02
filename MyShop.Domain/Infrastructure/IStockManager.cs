﻿using MyShop.Domain.Models;
using System.Threading.Tasks;

namespace MyShop.Domain.Infrastructure
{
    public interface IStockManager
    {
        Stock GetStockWithProduct(int stockId);
        bool EnoughStock(int stockId, int qty);
        Task PutStockOnHold(int stockId, int qty, string sessionId);
        Task RemoveStockFromHold(int stockId, int qty, string sessionId);
    }
}
