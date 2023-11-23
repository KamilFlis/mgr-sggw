using JwtAuthApp.Domain.Interfaces;
using JwtAuthApp.Domain.Models;
using JwtAuthApp.Persitence.Repositories.Interfaces;

namespace JwtAuthApp.Domain.Services;

public class DataService: IDataService
{
    private readonly IDataRepository _dataRepository;

    public DataService(IDataRepository dataRepository)
    {
        _dataRepository = dataRepository;
    }

    public async Task<ICollection<Data>> ListAsync()
    {
        return await _dataRepository.ListAsync();
    }
    
}