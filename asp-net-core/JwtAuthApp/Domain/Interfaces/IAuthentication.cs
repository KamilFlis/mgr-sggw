using JwtAuthApp.Domain.Models;

namespace JwtAuthApp.Domain.Interfaces;

public interface IAuthentication
{
    Task<string> Login(string email, string password);
    Task<User> Register(string email, string password);
}