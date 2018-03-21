using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.HealthChecks;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebB.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
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
