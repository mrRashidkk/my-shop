using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MyShop.UI.ViewModels.Admin;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class UsersController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;
        public UsersController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserViewModel vm)
        {
            var user = new IdentityUser()
            {
                UserName = vm.Username
            };

            await _userManager.CreateAsync(user, "password");

            var claim = new Claim("Role", "Manager");

            await _userManager.AddClaimAsync(user, claim);

            return Ok();
        }
        
    }
}
