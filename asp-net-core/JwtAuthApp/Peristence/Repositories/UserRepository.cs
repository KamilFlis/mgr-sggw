using JwtAuthApp.Domain.Models;
using JwtAuthApp.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthApp.Persitence.Repositories.Interfaces;

public class UserRepository: BaseRepository, IUserRepository
{
    public UserRepository(AppDbContext context): base(context) {}

    public async Task<ICollection<User>> ListAsync()
    {
        return await _context.Users.Include(u => u.Roles).ThenInclude(r => r.Privileges).AsNoTrackingWithIdentityResolution().ToListAsync();
    }

    public async Task<User> GetUserAsync(string email)
    {
        return await _context.Users.Include(u => u.Roles).ThenInclude(r => r.Privileges).AsNoTrackingWithIdentityResolution().FirstOrDefaultAsync(u => u.Email == email);
    }

    public async Task<int> Save(User user)
    {
        _context.Users.Add(user);
        return await _context.SaveChangesAsync();
    }
}