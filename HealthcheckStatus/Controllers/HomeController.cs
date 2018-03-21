using HealthcheckStatus.Models;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthcheckStatus.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            HttpClient client = new HttpClient();

            var healthA = await client.GetStringAsync("http://localhost:5000/health/status");
            var a = JsonConvert.DeserializeObject<StatusViewModel>(healthA);
            a.Name = "WebA";
            a.Description = a.Description.Replace("\\\\", "\\");

            var healthB = await client.GetStringAsync("http://localhost:5500/health/status");
            var b = JsonConvert.DeserializeObject<StatusViewModel>(healthB);
            b.Name = "WebB";

            var healthC = await client.GetStringAsync("http://localhost:5600/health/status");
            var c = JsonConvert.DeserializeObject<StatusViewModel>(healthC);
            c.Name = "WebC";

            return View(new[] { a, b, c });
        }
    }
}
