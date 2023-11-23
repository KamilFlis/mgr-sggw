using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApp.Domain.Interfaces;

public interface IHealthCheckService
{
    ActionResult<string> CheckHealth();
}