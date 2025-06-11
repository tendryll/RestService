using Microsoft.EntityFrameworkCore;
using RestService.Context;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApiDocument();

var connectionString = Environment.GetEnvironmentVariable("DB_CONNECTION_STRING")
                       ?? throw new InvalidOperationException("DB_CONNECTION_STRING is not set.");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseNpgsql(connectionString));

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseOpenApi();
    app.UseSwaggerUi();
}

app.UseAuthorization();

app.MapControllers();

app.Run();