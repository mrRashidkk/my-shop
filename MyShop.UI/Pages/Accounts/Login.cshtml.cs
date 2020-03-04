using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.UI.ViewModels;

namespace MyShop.UI.Pages.Accounts
{
    public class LoginModel : PageModel
    {
        private SignInManager<IdentityUser> _signInManager;

        public LoginModel(SignInManager<IdentityUser> signInManager)
        {
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }

        //public async Task<IActionResult> OnPost()
        //{
        //    var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, false, false);

        //    if(result.Succeeded)
        //    {
        //        return RedirectToPage("/Index");
        //    }
        //    return Page();
        //}
    }    
}
