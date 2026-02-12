using DevCompany.Application.Abstractions;
using DevCompany.Application.Locations;
using DevCompany.Application.Validators;
using FluentValidation;
using Microsoft.Extensions.DependencyInjection;

namespace DevCompany.Application.Extensions;

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
