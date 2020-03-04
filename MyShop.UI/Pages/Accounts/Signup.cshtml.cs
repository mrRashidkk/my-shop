using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using MyShop.UI.ViewModels;

namespace MyShop.UI.Pages.Accounts
{
    public class SignupModel : PageModel
    {
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;

        public SignupModel(UserManager<IdentityUser> userManager, SignInManager<IdentityUser> signInManager)
        {
            _userManager = userManager;
            _signInManager = signInManager;
        }

        public void OnGet()
        {
        }


        //public async Task<IActionResult> OnPost()
        //{
        //    if (ModelState.IsValid)
        //    {
        //        var success = await AddUser();

        //        if (success)
        //        {

        //        }

        //        var result = await _signInManager.PasswordSignInAsync(Input.UserName, Input.Password, false, false);

        //        if (result.Succeeded)
        //        {
        //            return RedirectToPage("/Index");
        //        }

        //        _signInManager.SignInAsync();

        //        return RedirectToPage("/Index");
        //    }
        //    return Page();
        //}

        //private async Task<bool> AddUser()
        //{
        //    var user = new IdentityUser()
        //    {
        //        UserName = Input.Username,
        //        Email = Input.Email,
        //        PhoneNumber = Input.PhoneNumber
        //    };

        //    string hash = new PasswordHasher<IdentityUser>().HashPassword(user, Input.Password);
        //    user.PasswordHash = hash;

        //    var createdUser = await _userManager.CreateAsync(user);
        //    if (createdUser.Succeeded)
        //    {
        //        var claim = new Claim("Role", "Customer");
        //        await _userManager.AddClaimAsync(user, claim);
        //    }
        //    return false;            
        //}
    }
}
