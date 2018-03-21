using HealthcheckStatus.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.HealthChecks;
using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace HealthcheckStatus.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index()
        {
            return View(new[] {
                await Retrieve("http://localhost:5000", "WebA"),
                await Retrieve("http://localhost:5500", "WebB"),
                await Retrieve("http://localhost:5600", "WebC")
            });
        }

        private async Task<StatusViewModel> Retrieve(string host, string name)
        {
            StatusViewModel model = new StatusViewModel { Name = name + " - " + host, CheckStatus = CheckStatus.Unknown };

            using (HttpClient client = new HttpClient())
            {
                try
                {
                    var health = await client.GetAsync(host + "/health/status");
                    if (health.IsSuccessStatusCode)
                    {
                        model = JsonConvert.DeserializeObject<StatusViewModel>(await health.Content.ReadAsStringAsync());
                        model.Name = name + " - " + host;
                        model.Description = model.Description.Replace("\\\\", "\\");
                    }
                }
                catch { }
            }

            return model;
        }
    }
}
