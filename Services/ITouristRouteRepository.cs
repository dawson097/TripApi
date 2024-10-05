using TripApi.Models;

namespace TripApi.Services;

/// <summary>
/// Repository service of tourist route
/// </summary>
public interface ITouristRouteRepository
{
    /// <summary>
    /// Get all of tourist route with search keyword
    /// </summary>
    /// <param name="keyword"></param>
    /// <returns></returns>
    IEnumerable<TouristRoute> GetAllRoutes(string keyword);

    /// <summary>
    /// Get single tourist route with route id
    /// </summary>
    /// <param name="routeId"></param>
    /// <returns></returns>
    TouristRoute GetRouteById(Guid routeId);
}