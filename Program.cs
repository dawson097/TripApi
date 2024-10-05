using Microsoft.EntityFrameworkCore;
using TripApi.Database;
using TripApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to container
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters();

builder.Services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();

builder.Services.AddDbContext<AppDbContext>(options =>
{
    var connectionString = builder.Configuration.GetConnectionString("NgSql");

    options.UseNpgsql(connectionString);
});

builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
}

app.MapControllers();

app.Run();