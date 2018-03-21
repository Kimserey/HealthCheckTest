using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.HealthChecks;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebA.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        [HttpGet("b")]
        public async Task<IActionResult> GetB()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("http://localhost:5500/health");
            if (result.IsSuccessStatusCode)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("c")]
        public async Task<IActionResult> GetC()
        {
            HttpClient client = new HttpClient();
            var result = await client.GetAsync("http://localhost:5600/health");
            if (result.IsSuccessStatusCode)
                return Ok();
            else
                return BadRequest();
        }

        [HttpGet("/health/status")]
        public async Task<IActionResult> GetStats([FromServices] IHealthCheckService service)
        {
            return Json(await service.CheckHealthAsync());
        }
    }
}
