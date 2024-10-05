using TripApi.Models;

namespace TripApi.Services;

/// <summary>
/// Repository service of tourist route picture
/// </summary>
public interface ITouristRoutePictureRepository : ICommonRepository
{
    IEnumerable<TouristRoutePicture> GetAllPicturesByRouteId(Guid routeId);
}