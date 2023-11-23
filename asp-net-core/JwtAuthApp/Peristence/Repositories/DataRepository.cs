using JwtAuthApp.Domain.Models;
using JwtAuthApp.Persitence.Contexts;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthApp.Persitence.Repositories.Interfaces;

public class DataRepository: BaseRepository, IDataRepository
{
    public DataRepository(AppDbContext context): base(context) {}

    public async Task<ICollection<Data>> ListAsync()
    {
        return await _context.Data.Include(d => d.Members).Include(d => d.Addresses).ThenInclude(a => a.City).ThenInclude(c => c.Country).AsNoTrackingWithIdentityResolution().ToListAsync();
    }
}