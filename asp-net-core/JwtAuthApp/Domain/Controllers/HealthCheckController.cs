using JwtAuthApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApp.Domain.Controllers;

[ApiController]
[Route("/api/health")]
public class HealthCheckController: ControllerBase
{
    private readonly IHealthCheckService _healthCheckService;

    public HealthCheckController(IHealthCheckService healthCheckService)
    {
        _healthCheckService = healthCheckService;
    }

    [HttpGet]
    public ActionResult<string> CheckHealth()
    {   
        return _healthCheckService.CheckHealth();
    }

}

