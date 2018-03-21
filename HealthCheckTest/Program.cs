﻿using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace HealthCheckTest
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseHealthChecks("/health")
                .UseStartup<Startup>()
                .UseUrls("http://localhost:5000")
                .Build();
    }
}
