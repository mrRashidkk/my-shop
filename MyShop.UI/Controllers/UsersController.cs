using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using System.Security.Claims;
using MyShop.UI.ViewModels.Admin;
using MyShop.UI.ViewModels;

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
        
        [HttpPost("CreateManager")]
        public async Task<IActionResult> CreateManager([FromBody] CreateUserViewModel vm)
        {
            var user = new IdentityUser()
            {
                UserName = vm.Username
            };
            string hash = new PasswordHasher<IdentityUser>().HashPassword(user, vm.Password);
            user.PasswordHash = hash;

            await _userManager.CreateAsync(user);

            var claim = new Claim("Role", "Manager");

            await _userManager.AddClaimAsync(user, claim);

            return Ok();
        }

    }
}
