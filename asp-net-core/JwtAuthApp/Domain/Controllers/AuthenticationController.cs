using JwtAuthApp.Domain.DTO;
using JwtAuthApp.Domain.Exceptions;
using JwtAuthApp.Domain.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApp.Domain.Controllers;

[ApiController]
[Route("/api/")]
public class AuthenticationController: ControllerBase
{
    private readonly IAuthentication _authenticationService;

    public AuthenticationController(IAuthentication authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [HttpPost("login")]
    [AllowAnonymous]
    public async Task<IActionResult> Login([FromBody] AuthUserDTO authUserDTO)
    {
        try 
        {
            string token = await _authenticationService.Login(authUserDTO.Email, authUserDTO.Password);
            return Ok(token);
        }
        catch(HttpResponseException ex)
        {
            return Unauthorized(ex.Value);
        }
    }

    [HttpPost("register")]
    [AllowAnonymous]
    public async Task<IActionResult> Register([FromBody] CreateAuthUserDTO createAuthUserDTO)
    {   
        try 
        {
            var result = await _authenticationService.Register(createAuthUserDTO.Email, createAuthUserDTO.Password);
            return result != null ? Created("User successfully created", result) : BadRequest();
        } 
        catch(HttpResponseException ex)
        {
            return BadRequest(ex.Value);
        }
    }

}