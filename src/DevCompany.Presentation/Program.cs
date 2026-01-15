using System.Globalization;
using System.Reflection;
using DevCompany.Application.Abstractions;
using DevCompany.Application.Locations;
using DevCompany.Application.Validators;
using DevCompany.Infrastructure;
using DevCompany.Infrastructure.Repositories;
using DevCompany.Presentation.Middleware;
using FluentValidation;
using Serilog;
using Serilog.Exceptions;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting web application.");

    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    builder.Services.AddControllers();
    builder.Services.AddOpenApi();

    builder.Services.AddSerilog((sp, lc) => lc
        .ReadFrom.Configuration(builder.Configuration)
        .ReadFrom.Services(sp)
        .Enrich.FromLogContext()
        .Enrich.WithExceptionDetails());

    builder.Services.AddScoped<DirectoryServiceDbContext>(
        _ => new (builder.Configuration.GetConnectionString("DirectoryServiceDb")!));
    builder.Services.AddScoped<ILocationsRepository, LocationsRepository>();
    builder.Services.AddScoped<ICommandHandler<Guid, CreateLocationCommand>, CreateLocationHandler>();
    builder.Services.AddScoped<CreateLocationHandler>();
    builder.Services.AddValidatorsFromAssembly(typeof(CustomValidators).Assembly);

    WebApplication app = builder.Build();

    app.UseExceptionHandlingMiddleware();
    app.UseSerilogRequestLogging();

    if (app.Environment.IsDevelopment())
    {
        app.MapOpenApi();
        app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DevCo"));
    }

    app.MapControllers();
    app.Run();
}
catch (Exception ex)
{
    Log.Fatal(ex, "Application terminated unexpectedly.");
}
finally
{
    Log.CloseAndFlush();
}
