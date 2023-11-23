using JwtAuthApp.Domain.EntityTypeConfiguration;
using JwtAuthApp.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace JwtAuthApp.Persitence.Contexts;

public class AppDbContext: DbContext
{
    public DbSet<User> Users { get; set; } = null!;
    public DbSet<Role> Roles { get; set; } = null!;
    public DbSet<Privilege> Privileges { get; set; } = null!;
    public DbSet<Data> Data { get; set; } = null!;

    private IConfiguration _configuration;

    public AppDbContext(DbContextOptions<AppDbContext> options, IConfiguration configuration): base(options) 
    { 
        _configuration = configuration;
    }

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder
            .UseNpgsql(_configuration.GetConnectionString("WebApiDatabase"))
            .UseSnakeCaseNamingConvention();
    }

    protected override void OnModelCreating(ModelBuilder builder)
    {
        new UserEntityTypeConfiguration().Configure(builder.Entity<User>());
        
        new RoleEntityTypeConfiguration().Configure(builder.Entity<Role>());
     
        new PrivilegeEntityTypeConfiguration().Configure(builder.Entity<Privilege>());

        new DataEntityTypeConfiguration().Configure(builder.Entity<Data>());

        new AddressEntityTypeConfiguration().Configure(builder.Entity<Address>());

        new CityEntityTypeConfiguration().Configure(builder.Entity<City>());

        new CountryEntityTypeConfiguration().Configure(builder.Entity<Country>());
        
        new MemberEntityTypeConfiguration().Configure(builder.Entity<Member>());

    }

    
}