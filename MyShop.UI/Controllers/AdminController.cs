﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MyShop.Application.ProductsAdmin;
using MyShop.Database;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]
    public class AdminController : Controller
    {
        private ApplicationDBContext _ctx;
        public AdminController(ApplicationDBContext ctx)
        {
            _ctx = ctx;
        }

        [HttpGet("products")]
        public async Task<IActionResult> GetProducts() => Ok(await new GetProducts(_ctx).Do());        

        [HttpGet("products/{id}")]
        public async Task<IActionResult> GetProduct(int id) => Ok(await new GetProduct(_ctx).Do(id));

        [HttpPost("products")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProduct.Request request) 
        {
            return Ok(await new CreateProduct(_ctx).Do(request));
        }

        [HttpDelete("products/{id}")]
        public async Task<IActionResult> DeleteProduct(int id) 
        {
            await new DeleteProduct(_ctx).Do(id);
            return Ok();
        }

        [HttpPut("products")]
        public async Task<IActionResult> UpdateProduct([FromBody] UpdateProduct.Request request) 
        {
            return Ok(await new UpdateProduct(_ctx).Do(request));
        }
    }
}