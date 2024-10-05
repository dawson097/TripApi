using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TripApi.Dtos.TouristRoutePicture;
using TripApi.Services;

namespace TripApi.Controllers;

[Route("api/tourist-routes/{routeId:guid}/pictures")]
[ApiController]
public class TouristRoutePicturesController : ControllerBase
{
    private ITouristRoutePictureRepository _pictureRepository;
    private IMapper _mapper;

    public TouristRoutePicturesController(ITouristRoutePictureRepository pictureRepository, IMapper mapper)
    {
        _pictureRepository = pictureRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetPicturesByRouteId(Guid routeId)
    {
        if (!_pictureRepository.RouteExists(routeId))
        {
            return NotFound("找不到任何旅游路线");
        }

        var picturesFromRepo = _pictureRepository.GetAllPicturesByRouteId(routeId);

        if (picturesFromRepo != null || picturesFromRepo.Count() <= 0)
        {
            return NotFound("找不到任何图片");
        }

        return Ok(_mapper.Map<IEnumerable<TouristRoutePictureDto>>(picturesFromRepo));
    }
}