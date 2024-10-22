using Microsoft.EntityFrameworkCore;
using TripApi.Models;

namespace TripApi.Database;

public class AppDbContext : DbContext
{
    public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
    {
    }

    public DbSet<TouristRoute> TouristRoutes { get; set; }

    public DbSet<TouristRoutePicture> TouristRoutePictures { get; set; }
}