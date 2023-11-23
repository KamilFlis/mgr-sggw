using JwtAuthApp.Domain.Models;

namespace JwtAuthApp.Persitence.Repositories.Interfaces;

public interface IUserRepository
{
    Task<ICollection<User>> ListAsync();

    Task<User> GetUserAsync(string email);

    Task<int> Save(User user);
}