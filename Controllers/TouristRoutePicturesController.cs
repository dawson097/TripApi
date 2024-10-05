using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TripApi.Dtos.TouristRoutePicture;
using TripApi.Services;

namespace TripApi.Controllers;

[Route("api/tourist-routes/{routeId:guid}")]
[ApiController]
public class TouristRoutePicturesController : ControllerBase
{
    private readonly ITouristRoutePictureRepository _pictureRepository;
    private readonly IMapper _mapper;

    public TouristRoutePicturesController(ITouristRoutePictureRepository pictureRepository, IMapper mapper)
    {
        _pictureRepository = pictureRepository;
        _mapper = mapper;
    }

    [HttpGet]
    public IActionResult GetAllPicturesByRouteId(Guid routeId)
    {
        if (!_pictureRepository.RoutesExists(routeId))
        {
            return NotFound($"当前旅游路线未找到，路线id: {routeId}");
        }

        var picturesFromRepo = _pictureRepository.GetAllPicturesByRouteId(routeId);

        if (picturesFromRepo != null || picturesFromRepo.Count() <= 0)
        {
            return NotFound("找不到任何照片");
        }

        return Ok(_mapper.Map<IEnumerable<TouristRoutePictureDto>>(picturesFromRepo));
    }
}