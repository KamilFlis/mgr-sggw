using JwtAuthApp.Domain.Models;

namespace JwtAuthApp.Persitence.Repositories.Interfaces;

public interface IRoleRepository
{
    // Task<ICollection<Role>> ListAsync();

    Task<Role> GetRoleAsync(string name);
}