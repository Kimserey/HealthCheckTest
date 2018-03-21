using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.HealthChecks;
using System.Net.Http;
using System.Threading.Tasks;

namespace WebC.Controllers
{
    [Route("api/test")]
    public class TestController : Controller
    {
        public IActionResult Get()
        {
            return Ok();
        }

        [HttpGet("/health/status")]
        public async Task<IActionResult> GetStats([FromServices] IHealthCheckService service)
        {
            return Json(await service.CheckHealthAsync());
        }
    }
}
