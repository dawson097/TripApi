using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using TripApi.Dtos.TouristRoute;
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
    public IActionResult GetAllRoutes()
    {
        var routesFromRepo = _routeRepository.GetAllRoutes();

        if (routesFromRepo == null || routesFromRepo.Count() < 0)
        {
            return NotFound("找不到任何旅游路线");
        }

        return Ok(_mapper.Map<IEnumerable<TouristRouteDto>>(routesFromRepo));
    }

    [HttpGet("{routeId:guid}")]
    public IActionResult GetRouteById(Guid routeId)
    {
        var routeFromRepo = _routeRepository.GetRouteById(routeId);

        if (routeFromRepo == null)
        {
            return NotFound($"找不到当前旅游路线，路线id: {routeId}");
        }

        return Ok(_mapper.Map<TouristRouteDto>(routeFromRepo));
    }
}