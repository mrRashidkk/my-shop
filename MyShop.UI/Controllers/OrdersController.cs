using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Application.OrdersAdmin;
using MyShop.Database;
using Microsoft.AspNetCore.Authorization;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class OrdersController : Controller
    {
        private ApplicationDBContext _ctx;
        public OrdersController(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet]
        public IActionResult GetOrders(int status) => Ok(new GetOrders(_ctx).Do(status));

        [HttpGet("{id}")]
        public IActionResult GetOrder(int id) => Ok(new GetOrder(_ctx).Do(id));        

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateOrder(int id)
        {
            return Ok(await new UpdateOrder(_ctx).Do(id));
        }
    }
}