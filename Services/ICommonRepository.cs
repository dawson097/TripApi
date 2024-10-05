namespace TripApi.Services;

/// <summary>
/// A common repository to provide common method between tourist route repository and tourist route picture
/// </summary>
public interface ICommonRepository
{
    bool RouteExists(Guid routeId);

    bool Save();
}