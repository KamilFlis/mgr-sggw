using JwtAuthApp.Persitence.Contexts;

namespace JwtAuthApp.Persitence.Repositories;

public class BaseRepository
{
    protected readonly AppDbContext _context;

    public BaseRepository(AppDbContext context)
    {
        _context = context;
    }
    
}