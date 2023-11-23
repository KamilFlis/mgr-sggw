using JwtAuthApp.Domain.Models;

namespace JwtAuthApp.Domain.Interfaces;

public interface IDataService
{
    Task<ICollection<Data>> ListAsync();
}