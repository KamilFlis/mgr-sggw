using JwtAuthApp.Persitence.Repositories.Interfaces;

namespace JwtAuthApp.Configuration;

public static class ConfigureRepositories
{
    public static IServiceCollection AddRepositories(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IUserRepository, UserRepository>();
        services.AddScoped<IDataRepository, DataRepository>();
        services.AddScoped<IRoleRepository, RoleRepository>();

        return services;
    }
}