using Microsoft.EntityFrameworkCore;
using TripApi.Database;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("NgSql");

    options.UseNpgsql(connectionString);
});

var app = builder.Build();

app.Run();