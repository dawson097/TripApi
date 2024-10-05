using Microsoft.EntityFrameworkCore;
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

    public IEnumerable<TouristRoute> GetAllRoutes(string keyword)
    {
        IQueryable<TouristRoute> queryRes = _context.TouristRoutes
            .Include(route => route.TouristRoutePictures);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            keyword = keyword.Trim();
            queryRes = queryRes.Where(route => route.Title.Contains(keyword));
        }

        return queryRes.ToList();
    }

    public TouristRoute GetRouteById(Guid routeId)
    {
        return _context.TouristRoutes.FirstOrDefault(route => route.Id == routeId);
    }
}