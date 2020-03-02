using System.Threading.Tasks;
using MyShop.Domain.Infrastructure;

namespace MyShop.Application.ProductsAdmin
{
    public class DeleteProduct
    {
        private IProductManager _productManager;
        public DeleteProduct(IProductManager productManager)
        {
            _productManager = productManager;
        }

        public Task<int> Do(int id)
        {
            return _productManager.DeleteProduct(id);
        } 
    }
}
