using Microsoft.Extensions.HealthChecks;

namespace HealthcheckStatus.Models
{
    public class StatusViewModel
    {
        public string Name { get; set; }
        public CheckStatus CheckStatus { get; set; }
        public string Description { get; set; }
    }
}
