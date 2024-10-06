using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using TripApi.Database;
using TripApi.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to container
builder.Services.AddControllers(options =>
{
    options.ReturnHttpNotAcceptable = true;
}).AddXmlDataContractSerializerFormatters()
.ConfigureApiBehaviorOptions(options =>
{
    options.InvalidModelStateResponseFactory = context =>
    {
        var problemDetail = new ValidationProblemDetails(context.ModelState)
        {
            Type = "Valid Error",
            Title = "数据验证失败",
            Status = StatusCodes.Status422UnprocessableEntity,
            Detail = "请看详细说明",
            Instance = context.HttpContext.Request.Path
        };

        problemDetail.Extensions.Add("traceId", context.HttpContext.TraceIdentifier);

        return new UnprocessableEntityObjectResult(problemDetail)
        {
            ContentTypes = { "application/problem+json" }
        };
    };
});

builder.Services.AddTransient<ITouristRouteRepository, TouristRouteRepository>();
builder.Services.AddTransient<ITouristRoutePictureRepository, TouristRoutePictureRepository>();

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