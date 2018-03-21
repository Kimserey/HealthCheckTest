# Prototype for Healthcheck implementation in ASP.NET Core

## How to implement

Get the source code of the HealthChecks implementation from ASP.NET Core GitHub:

- Microsoft.AspNetCore.HealthChecks
- Microsoft.Extensions.HealthChecks

Register the healthchecks in `Startup.cs` as followed:

```
services.AddHealthChecks(checks => checks
    .AddValueTaskCheck("I am alive", () => new ValueTask<IHealthCheckResult>(HealthCheckResult.Healthy("status code OK (200)")))
    .AddUrlCheck("http://localhost:5500/health")
    .AddUrlCheck("http://localhost:5600/health")
);
```

The first check specifies that the service itself is reacheable while the subsequents target the services dependencies.

Register the health endpoint from `Program.cs`:

```
.UseHealthChecks("/health")
```

## Screenshots

When all services are up and their dependencies are accessible:

![healthy](healthy.png)

When __WebB++ goes down, __WebA__ becomes unhealthy and the broken dependency can be identified in the description:

![unhealthy](unhealthy.png)