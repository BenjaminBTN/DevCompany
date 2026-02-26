using DepartmentService.Application.Locations;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using Shared.Core.Abstractions;

namespace DepartmentService.Application.Extensions;

public static class InjectExtensions
{
    public static IServiceCollection AddApplication(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<Guid, CreateLocationCommand>, CreateLocationHandler>();
        services.AddScoped<CreateLocationHandler>();
        services.AddValidatorsFromAssembly(typeof(InjectExtensions).Assembly);

        return services;
    }
}
