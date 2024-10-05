using TripApi.Database;
using TripApi.Models;

namespace TripApi.Services;

public class TouristRoutePictureRepository : CommonRepository, ITouristRoutePictureRepository
{
    private readonly AppDbContext _context;

    public TouristRoutePictureRepository(AppDbContext context) : base(context)
    {
        _context = context;
    }

    public IEnumerable<TouristRoutePicture> GetAllPicturesByRouteId(Guid routeId)
    {
        return _context.TouristRoutePictures.Where(picture => picture.TouristRouteId == routeId)
            .ToList();
    }

    public TouristRoutePicture GetPictureById(int pictureId)
    {
        return _context.TouristRoutePictures.Where(picture => picture.Id == pictureId)
            .FirstOrDefault();
    }
}