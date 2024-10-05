using TripApi.Database;

namespace TripApi.Services;

public class CommonRepository : ICommonRepository
{
    private readonly AppDbContext _context;

    public CommonRepository(AppDbContext context)
    {
        _context = context;
    }

    public bool RouteExists(Guid routeId)
    {
        return _context.TouristRoutes.Any(route => route.Id == routeId);
    }
}