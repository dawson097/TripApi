using TripApi.Database;
using TripApi.Models;

namespace TripApi.Services;

public class TouristRouteRepository : ITouristRouteRepository
{
    private readonly AppDbContext _context;

    public TouristRouteRepository(AppDbContext context)
    {
        _context = context;
    }

    public IEnumerable<TouristRoute> GetAllRoutes()
    {
        return _context.TouristRoutes;
    }

    public TouristRoute GetRouteById(Guid routeId)
    {
        return _context.TouristRoutes.FirstOrDefault(route => route.Id == routeId);
    }
}