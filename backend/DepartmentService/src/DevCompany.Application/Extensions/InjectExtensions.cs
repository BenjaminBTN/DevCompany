using DepartmentService.Application.Abstractions;
using DepartmentService.Application.Locations;
using DepartmentService.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DepartmentService.Application.Extensions;

public static class InjectExtensions
{
    public static IServiceCollection AddApplicatinon(this IServiceCollection services)
    {
        services.AddScoped<ICommandHandler<Guid, CreateLocationCommand>, CreateLocationHandler>();
        services.AddScoped<CreateLocationHandler>();
        services.AddValidatorsFromAssembly(typeof(CustomValidators).Assembly);

        return services;
    }
}
