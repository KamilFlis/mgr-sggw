using JwtAuthApp.Domain.Models;
using JwtAuthApp.Persitence.Repositories.Interfaces;
using JwtAuthApp.Domain.Interfaces;
using JwtAuthApp.Domain.Exceptions;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;

namespace JwtAuthApp.Domain.Services;

public class AuthenticationService: IAuthentication
{
    private readonly IConfiguration _configuration;
    private readonly IUserRepository _userRepository;
    private readonly IRoleRepository _roleRepository;

    public AuthenticationService(IConfiguration configuration, IUserRepository userRepository, IRoleRepository roleRepository)
    {
        _configuration = configuration;
        _userRepository = userRepository;
        _roleRepository = roleRepository;
    }

    public async Task<string> Login(string email, string password)
    {
        User user = await _userRepository.GetUserAsync(email);

        if(user == null)
        {
            throw new HttpResponseException(401, "Incorrect credentials");
        }

        bool MatchPassword = BCrypt.Net.BCrypt.Verify(password, user.Password);

        if(!MatchPassword)
        {
            throw new HttpResponseException(401, "Incorrect credentials");
        }

        string token = GenerateJSONWebToken(user);

        return token;
    }

    public async Task<User> Register(string email, string password)
    {
        User AlreadyExistsUser = await _userRepository.GetUserAsync(email);

        if(AlreadyExistsUser != null)
        {
            throw new HttpResponseException(400, "User already exists");
        }

        string HashedPassword = BCrypt.Net.BCrypt.HashPassword(password);
        
        Role role = await _roleRepository.GetRoleAsync("ROLE_USER");

        User newUser = new User { Email = email, Password = HashedPassword, Roles = new List<Role>() };
        newUser.Roles.Add(role);

        await _userRepository.Save(newUser);
    
        return await _userRepository.GetUserAsync(newUser.Email);
    }

    private string GenerateJSONWebToken(User userInfo)
    {
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration.GetValue<string>("Jwt:Key")));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

        var claims = new List<Claim>
        {
            new Claim("Sub", userInfo.Id.ToString()),
            new Claim(ClaimTypes.Email, userInfo.Email),
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
        };

        foreach(var role in userInfo.Roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role.Name));
        }
            
        var token = new JwtSecurityToken(issuer: _configuration.GetValue<string>("Jwt:Issuer"),
            audience: _configuration.GetValue<string>("Jwt:Issuer"),
            claims: claims,
            expires: DateTime.Now.AddMinutes(120),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }

}