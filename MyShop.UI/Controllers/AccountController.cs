using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyShop.UI.Pages.Accounts;
using MyShop.UI.ViewModels;

namespace MyShop.UI.Controllers
{
    public class AccountController : Controller
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;

        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager)
        {
            _signInManager = signInManager;
            _userManager = userManager;
        }

        [HttpGet]
        public async Task<IActionResult> Logout()
        {
            await _signInManager.SignOutAsync();

            return RedirectToPage("/Index");
        }

        [HttpPost]
        public async Task<IActionResult> Login(LoginViewModel vm)
        {
            var result = await _signInManager.PasswordSignInAsync(vm.UserName, vm.Password, false, false);

            if (result.Succeeded)
            {
                return RedirectToPage("/Index");
            }
            return RedirectToPage("/Accounts/Login");
        }

        [HttpPost]
        public async Task<IActionResult> Signup(SignUpViewModel vm)
        {
            if (ModelState.IsValid)
            {
                var user = new IdentityUser()
                {
                    UserName = vm.Username,
                    Email = vm.Email,
                    PhoneNumber = vm.PhoneNumber
                };
                string hash = new PasswordHasher<IdentityUser>().HashPassword(user, vm.Password);
                user.PasswordHash = hash;

                await _userManager.CreateAsync(user);
                var claim = new Claim("Role", "Customer");
                await _userManager.AddClaimAsync(user, claim);                

                await _signInManager.SignInAsync(user, false);                

                return RedirectToPage("/Index");
            }
            return RedirectToPage("/Accounts/Signup");
        }

        public IActionResult Index()
        {
            return View();
        }        
    }
}