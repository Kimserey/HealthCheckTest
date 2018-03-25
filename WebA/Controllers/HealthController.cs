using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.HealthChecks;
using System.Threading;
using System.Threading.Tasks;

namespace WebA.Controllers
{
    [Route("health")]
    public class HealthController : Controller
    {
        private IHealthCheckService _service;

        public HealthController(IHealthCheckService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await GetHealthCheckResult();
            return Json(result.CheckStatus.ToString());
        }

        [HttpGet("status")]
        public async Task<IActionResult> GetStatus()
        {
            return Json(await GetHealthCheckResult());
        }

        private Task<CompositeHealthCheckResult> GetHealthCheckResult()
        {
            var timeoutTokenSource = new CancellationTokenSource(5000);
            return _service.CheckHealthAsync(timeoutTokenSource.Token);
        }
    }
}
