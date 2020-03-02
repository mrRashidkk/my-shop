using System.Threading.Tasks;
using MyShop.Domain.Infrastructure;

namespace MyShop.Application.StockAdmin
{
    public class DeleteStock
    {
        private readonly IStockManager _stockManager;

        public DeleteStock(IStockManager stockManager)
        {
            _stockManager = stockManager;
        }

        public Task<int> Do(int id)
        {
            return _stockManager.DeleteStock(id);
        }        
    }
}
