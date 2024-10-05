using TripApi.Models;

namespace TripApi.Services;

/// <summary>
/// Repository service of tourist route
/// </summary>
public interface ITouristRouteRepository : ICommonRepository
{
    /// <summary>
    /// Get all of tourist route with search keyword and operator type and rating value
    /// </summary>
    /// <param name="keyword"></param>
    /// <param name="ratingOperator"></param>
    /// <param name="ratingValue"></param>
    /// <returns></returns>
    IEnumerable<TouristRoute> GetAllRoutes(string keyword, string ratingOperator, int? ratingValue);

    /// <summary>
    /// Get single tourist route with route id
    /// </summary>
    /// <param name="routeId"></param>
    /// <returns></returns>
    TouristRoute GetRouteById(Guid routeId);

    /// <summary>
    /// Add a new tourist route
    /// </summary>
    /// <param name="route">route entity data</param>
    void AddRoute(TouristRoute route);
}