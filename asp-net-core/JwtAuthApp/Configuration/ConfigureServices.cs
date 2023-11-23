using AutoMapper;
using JwtAuthApp.Domain.Interfaces;
using JwtAuthApp.Domain.Mapper;
using JwtAuthApp.Domain.Services;

namespace JwtAuthApp.Configuration;

public static class ConfigureServices
{
    public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<IHealthCheckService, HealthCheckService>();
        services.AddScoped<IUserService, UserService>();
        services.AddScoped<IDataService, DataService>();
        services.AddScoped<IAuthentication, AuthenticationService>();

        var mapperConfig = new MapperConfiguration(mc =>
        {
            mc.AddProfile(new MappingProfile());
        });

        // mapperConfig.AssertConfigurationIsValid();

        IMapper mapper = mapperConfig.CreateMapper();    
        services.AddSingleton(mapper);
        // services.AddAutoMapper(mapperConfig);

        return services;
    }
}