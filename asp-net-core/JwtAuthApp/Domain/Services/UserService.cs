using JwtAuthApp.Domain.Interfaces;
using JwtAuthApp.Domain.Models;
using JwtAuthApp.Persitence.Repositories.Interfaces;

namespace JwtAuthApp.Domain.Services;

public class UserService: IUserService
{
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public UserService(IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<ICollection<User>> ListAsync()
    {
        return await _userRepository.ListAsync();
    }

}