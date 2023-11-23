using JwtAuthApp.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApp.Domain.Services;

public class HealthCheckService: IHealthCheckService
{
    private readonly IConfiguration _configuration;

    public HealthCheckService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public ActionResult<string> CheckHealth() 
    {
        string? ProfileMessage = _configuration["Profile:Message"];
        return ProfileMessage + " is live\n";
    }
}