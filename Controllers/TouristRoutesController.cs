using AutoMapper;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using TripApi.Dtos.TouristRoute;
using TripApi.Models;
using TripApi.ResourceParameters;
using TripApi.Services;

namespace TripApi.Controllers;

[Route("api/tourist-routes")]
[ApiController]
public class TouristRoutesController : ControllerBase
{
    private readonly ITouristRouteRepository _routeRepository;
    private readonly IMapper _mapper;

    public TouristRoutesController(ITouristRouteRepository routeRepository, IMapper mapper)
    {
        _routeRepository = routeRepository;
        _mapper = mapper;
    }

    [HttpGet]
    [HttpHead]
    public IActionResult GetAllRoutes([FromQuery] TouristRouteResourceParameters parameters)
    {
        var routesFromRepo = _routeRepository
            .GetAllRoutes(parameters.Keyword, parameters.RatingOperator, parameters.RatingValue);

        if (routesFromRepo == null || routesFromRepo.Count() <= 0)
        {
            return NotFound("找不到任何旅游路线");
        }

        return Ok(_mapper.Map<IEnumerable<TouristRouteDto>>(routesFromRepo));
    }

    [HttpGet("{routeId:guid}", Name = "GetRouteById")]
    [HttpHead]
    public IActionResult GetRouteById(Guid routeId)
    {
        var routeFromRepo = _routeRepository.GetRouteById(routeId);

        if (routeFromRepo == null)
        {
            return NotFound($"找不到当前旅游路线，路线id: {routeId}");
        }

        return Ok(_mapper.Map<TouristRouteDto>(routeFromRepo));
    }

    [HttpPost]
    public IActionResult AddRoute([FromBody] TouristRouteAddDto routeAddDto)
    {
        var routeModel = _mapper.Map<TouristRoute>(routeAddDto);

        _routeRepository.AddRoute(routeModel);
        _routeRepository.Save();

        var routeToReturn = _mapper.Map<TouristRouteDto>(routeModel);

        return CreatedAtRoute("GetRouteById", new { routeId = routeToReturn.Id }, routeToReturn);
    }

    [HttpPut("{routeId:guid}")]
    public IActionResult UpdateTouristRoute([FromRoute] Guid routeId,
        [FromBody] TouristRouteUpdateDto routeUpdateDto)
    {
        if (!_routeRepository.RouteExists(routeId))
        {
            return NotFound("旅游路线找不到");
        }

        var routeFromRepo = _routeRepository.GetRouteById(routeId);

        _mapper.Map(routeUpdateDto, routeFromRepo);
        _routeRepository.Save();

        return NoContent();
    }

    [HttpPatch("{routeId:guid}")]
    public IActionResult PartialUpdateRoute([FromRoute] Guid routeId,
        [FromBody] JsonPatchDocument<TouristRouteUpdateDto> patchDocument)
    {
        if (!_routeRepository.RouteExists(routeId))
        {
            return NotFound("旅游路线找不到");
        }

        var routeFromRepo = _routeRepository.GetRouteById(routeId);
        var routeToPatch = _mapper.Map<TouristRouteUpdateDto>(routeFromRepo);

        patchDocument.ApplyTo(routeToPatch, ModelState);

        if (!TryValidateModel(routeToPatch))
        {
            return ValidationProblem(ModelState);
        }

        _mapper.Map(routeToPatch, routeFromRepo);
        _routeRepository.Save();

        return NoContent();
    }
}