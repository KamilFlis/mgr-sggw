using AutoMapper;
using JwtAuthApp.Domain.DTO;
using JwtAuthApp.Domain.Interfaces;
using JwtAuthApp.Domain.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JwtAuthApp.Domain.Controllers;

[ApiController]
[Route("/api/[controller]")]
public class DataController: ControllerBase
{
    private readonly IMapper _mapper;
    private readonly IDataService _dataService;
    
    public DataController(IMapper mapper, IDataService dataService)
    {
        _mapper = mapper;
        _dataService = dataService;
    }

    [HttpGet]
    [Authorize]
    public async Task<ICollection<DataDTO>> GetAllAsync()
    {
        ICollection<Data> data =  await _dataService.ListAsync();
        return _mapper.Map<ICollection<DataDTO>>(data);
    }
}