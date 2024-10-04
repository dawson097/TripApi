using Microsoft.EntityFrameworkCore;
using TripApi.Database;

var builder = WebApplication.CreateBuilder(args);

// Add services to container
builder.Services.AddControllers();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("NgSql");

    options.UseNpgsql(connectionString);
});

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();

app.Run();