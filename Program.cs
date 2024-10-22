using Microsoft.EntityFrameworkCore;
using TripApi.Database;
using TripApi.Models;
using TripApi.Services;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("NgSql");

    options.UseNpgsql(connectionString);
});

var app = builder.Build();

app.MapControllers();

app.Run();