using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TripApi.Dtos.TouristRoutePicture;
using TripApi.Models;
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
    public IActionResult GetAllPicturesByRouteId(Guid routeId)
    {
        if (!_pictureRepository.RouteExists(routeId))
        {
            return NotFound("找不到任何旅游路线");
        }

        var picturesFromRepo = _pictureRepository.GetAllPicturesByRouteId(routeId);

        if (picturesFromRepo == null || picturesFromRepo.Count() <= 0)
        {
            return NotFound("找不到任何图片");
        }

        return Ok(_mapper.Map<IEnumerable<TouristRoutePictureDto>>(picturesFromRepo));
    }

    [HttpGet("{pictureId:int}", Name = "GetPictureById")]
    public IActionResult GetPictureById(Guid routeId, int pictureId)
    {
        if (!_pictureRepository.RouteExists(routeId))
        {
            return NotFound("找不到任何旅游路线");
        }

        var pictureFromRepo = _pictureRepository.GetPictureById(pictureId);

        if (pictureFromRepo == null)
        {
            return NotFound($"找不到该图片，图片id: {pictureId}");
        }

        return Ok(_mapper.Map<TouristRoutePictureDto>(pictureFromRepo));
    }

    [HttpPost]
    public IActionResult AddRoutePicture([FromRoute] Guid routeId, [FromBody] TouristRoutePictureAddDto pictureAddDto)
    {
        if (!_pictureRepository.RouteExists(routeId))
        {
            return NotFound("找不到任何旅游路线");
        }

        var pictureModel = _mapper.Map<TouristRoutePicture>(pictureAddDto);

        _pictureRepository.AddPicture(routeId, pictureModel);
        _pictureRepository.Save();

        var pictureToReturn = _mapper.Map<TouristRoutePictureDto>(pictureModel);

        return CreatedAtRoute("GetPictureById", new
        {
            routeId = pictureModel.TouristRouteId,
            picture = pictureModel.Id
        }, pictureToReturn);
    }
}