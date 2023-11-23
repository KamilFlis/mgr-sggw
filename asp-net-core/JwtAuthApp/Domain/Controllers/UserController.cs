using AutoMapper;
using JwtAuthApp.Domain.DTO;
using JwtAuthApp.Domain.Interfaces;
using JwtAuthApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApp.Domain.Controllers;

[ApiController]
[Route("/api/users")]
public class UserController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IUserService _userService;

    public UserController(IMapper mapper ,IUserService userService)
    {
        _mapper = mapper;
        _userService = userService;
    }

    [HttpGet]
    [Authorize(Roles = "ROLE_ADMIN")]
    public async Task<ICollection<UserDTO>> GetAllAsync()
    {
        ICollection<User> users =  await _userService.ListAsync();
        return _mapper.Map<ICollection<UserDTO>>(users);
    }

}