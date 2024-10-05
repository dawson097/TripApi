namespace TripApi.Services;

public interface ICommonRepository
{
    bool RoutesExists(Guid routeId);
}