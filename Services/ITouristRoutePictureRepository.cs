using TripApi.Models;

namespace TripApi.Services;

/// <summary>
/// Repository service of tourist route picture
/// </summary>
public interface ITouristRoutePictureRepository : ICommonRepository
{
    /// <summary>
    /// Get all of tourist route picture from single tourist route with route id
    /// </summary>
    /// <param name="routeId"></param>
    /// <returns></returns>
    IEnumerable<TouristRoutePicture> GetAllPicturesByRouteId(Guid routeId);

    /// <summary>
    /// Get single tourist route picture with picture id
    /// </summary>
    /// <param name="pictureId"></param>
    /// <returns></returns>
    TouristRoutePicture GetPictureById(int pictureId);

    /// <summary>
    /// Add tourist route picture
    /// </summary>
    /// <param name="routeId"></param>
    /// <param name="routePicture">route picture entity</param>
    void AddPicture(Guid routeId, TouristRoutePicture routePicture);
}