using System.Globalization;
using DepartmentService.Application.Extensions;
using DepartmentService.Infrastructure.Extensions;
using DepartmentService.Presentation.Extensions;
using DepartmentService.Presentation.Middleware;
using Serilog;

Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .WriteTo.Console(formatProvider: CultureInfo.InvariantCulture)
    .CreateBootstrapLogger();

try
{
    Log.Information("Starting web application.");

    WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

    builder.Services.AddWeb();
    builder.Services.AddSerilogLogging(builder.Configuration);
    builder.Services.AddApplicatinon();
    builder.Services.AddInfrastructure(builder.Configuration);

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
