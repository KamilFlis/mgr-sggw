using JwtAuthApp.Domain.Models;
using JwtAuthApp.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthApp.Persitence.Repositories.Interfaces;

public class RoleRepository: BaseRepository, IRoleRepository
{
    public RoleRepository(AppDbContext context): base(context) {}

    public async Task<Role> GetRoleAsync(string name)
    {
        return await _context.Roles.FirstOrDefaultAsync(r => r.Name == name);
    }

}