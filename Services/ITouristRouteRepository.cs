using TripApi.Models;

namespace TripApi.Services;

/// <summary>
///     Repository service of tourist route
/// </summary>
public interface ITouristRouteRepository
{
    /// <summary>
    ///     Get all the tourist routes
    /// </summary>
    /// <returns></returns>
    IEnumerable<TouristRoute> GetAllRoutes();

    /// <summary>
    ///     Get single tourist route with route id
    /// </summary>
    /// <param name="routeId"></param>
    /// <returns></returns>
    TouristRoute GetRouteById(Guid routeId);
}