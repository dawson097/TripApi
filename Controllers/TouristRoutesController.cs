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
    public IActionResult GetTouristRoutes()
    {
        return Ok(_routeRepository.GetAllRoutes());
    }

    [HttpGet("{routeId:guid}")]
    public IActionResult GetTouristRoute(Guid routeId)
    {
        return Ok(_routeRepository.GetRouteById(routeId));
    }
}