using DevCompany.Application.Locations;
using DevCompany.Infrastructure.Repositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace DevCompany.Infrastructure.Extensions;

public static class InjectExtensions
{
    public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
    {
        services.AddScoped<DirectoryServiceDbContext>(_ => new(configuration.GetConnectionString("DirectoryServiceDb")!));
        services.AddScoped<ILocationsRepository, LocationsRepository>();

        return services;
    }
}
