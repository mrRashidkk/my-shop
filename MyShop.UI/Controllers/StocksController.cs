using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MyShop.Application.StockAdmin;
using Microsoft.AspNetCore.Authorization;

namespace MyShop.UI.Controllers
{
    [Route("[controller]")]
    [Authorize(Policy = "Manager")]
    public class StocksController : Controller
    {
        [HttpGet]
        public IActionResult GetStocks([FromServices] GetStock getStock) => 
            Ok(getStock.Do());

        [HttpPost]
        public async Task<IActionResult> CreateStock([FromServices] CreateStock createStock, [FromBody] CreateStock.Request request) =>
            Ok(await createStock.Do(request));

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStock([FromServices] DeleteStock deleteStock, int id) =>
            Ok(await deleteStock.Do(id));        

        [HttpPut]
        public async Task<IActionResult> UpdateStock([FromServices] UpdateStock updateStock, [FromBody] UpdateStock.Request request) =>
            Ok(await updateStock.Do(request));        
    }
}