using JwtAuthApp.Domain.Models;

namespace JwtAuthApp.Persitence.Repositories.Interfaces;

public interface IDataRepository
{
    Task<ICollection<Data>> ListAsync();
}