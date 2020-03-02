using System.Threading.Tasks;

namespace MyShop.Domain.Infrastructure
{
    public interface IUserManager
    {
        Task CreateManagerUser(string username, string password);
    }
}
