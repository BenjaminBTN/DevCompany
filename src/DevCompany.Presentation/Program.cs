using DevCompany.Infrastructure;

WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddOpenApi();

builder.Services.AddScoped<DirectoryServiceDbContext>(_
    => new (builder.Configuration.GetConnectionString("DirectoryServiceDb")!));

WebApplication app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwaggerUI(options => options.SwaggerEndpoint("/openapi/v1.json", "DevCo"));
}

app.MapControllers();
app.Run();