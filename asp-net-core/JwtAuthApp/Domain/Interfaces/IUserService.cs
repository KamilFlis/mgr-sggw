using JwtAuthApp.Domain.Models;

namespace JwtAuthApp.Domain.Interfaces;

public interface IUserService
{
    Task<ICollection<User>> ListAsync();
}