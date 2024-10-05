using Microsoft.AspNetCore.Mvc;
using TripApi.Services;

namespace TripApi.Controllers;

[Route("api/tourist-routes")]
[ApiController]
public class TouristRoutesController : ControllerBase
{
    private readonly ITouristRouteRepository _routeRepository;

    public TouristRoutesController(ITouristRouteRepository routeRepository)
    {
        _routeRepository = routeRepository;
    }

    [HttpGet]
    public IActionResult GetAllRoutes()
    {
        var routesFromRepo = _routeRepository.GetAllRoutes();

        if (routesFromRepo == null || routesFromRepo.Count() < 0)
        {
            return NotFound("找不到任何旅游路线");
        }

        return Ok(routesFromRepo);
    }

    [HttpGet("{routeId:guid}")]
    public IActionResult GetRouteById(Guid routeId)
    {
        var routeFromRepo = _routeRepository.GetRouteById(routeId);

        if (routeFromRepo == null)
        {
            return NotFound($"找不到当前旅游路线，路线id: {routeId}");
        }

        return Ok(routeFromRepo);
    }
}