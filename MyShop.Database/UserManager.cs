using Microsoft.AspNetCore.Identity;
using MyShop.Domain.Infrastructure;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace MyShop.Database
{
    public class UserManager : IUserManager
    {
        private UserManager<IdentityUser> _userManager;

        public UserManager(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task CreateManagerUser(string username, string password)
        {
            var user = new IdentityUser()
            {
                UserName = username
            };

            await _userManager.CreateAsync(user, password);

            var claim = new Claim("Role", "Manager");

            await _userManager.AddClaimAsync(user, claim);
        }
    }
}
