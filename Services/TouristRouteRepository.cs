using Microsoft.EntityFrameworkCore;
using TripApi.Database;
using TripApi.Models;

namespace TripApi.Services;

public class TouristRouteRepository : CommonRepository, ITouristRouteRepository
{
    private readonly AppDbContext _context;

    public TouristRouteRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<TouristRoute> GetAllRoutes(string keyword, string ratingOperator, int? ratingValue)
    {
        IQueryable<TouristRoute> queryRes = _context.TouristRoutes
            .Include(route => route.TouristRoutePictures);

        if (!string.IsNullOrWhiteSpace(keyword))
        {
            keyword = keyword.Trim();
            queryRes = queryRes.Where(route => route.Title.Contains(keyword));
        }

        if (ratingValue > 0)
        {
            queryRes = ratingOperator switch
            {
                "largerThan" => queryRes = queryRes.Where(route => route.Rating >= ratingValue),
                "lessThan" => queryRes = queryRes.Where(route => route.Rating <= ratingValue),
                _ => queryRes = queryRes.Where(route => route.Rating == ratingValue)
            };
        }

        return queryRes.ToList();
    }

    public TouristRoute GetRouteById(Guid routeId)
    {
        return _context.TouristRoutes.FirstOrDefault(route => route.Id == routeId);
    }

    public void AddRoute(TouristRoute route)
    {
        if (route == null) throw new ArgumentNullException(nameof(route));

        _context.TouristRoutes.Add(route);
    }
}