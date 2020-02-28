using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Database;
using Microsoft.AspNetCore.Authorization;
using MyShop.Application.UsersAdmin;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Admin")]
    public class UsersController : Controller
    {
        private CreateUser _createUser;
        public UsersController(CreateUser createUser)
        {
            _createUser = createUser;
        }

        [HttpPost]
        public async Task<IActionResult> CreateUser([FromBody] CreateUser.Request request)
        {
            await _createUser.Do(request);
            return Ok();
        }
        
    }
}
