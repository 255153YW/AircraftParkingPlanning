using AircraftParkingPlanning.Model;
using Microsoft.AspNetCore.Mvc;
using System.Text.Json.Nodes;

namespace AircraftParkingPlanning.Controllers
{
  [ApiController]
  [Route("[controller]")]
  public class FlightsController : ControllerBase
  {    

    private readonly ILogger<FlightsController> _logger;
    private readonly Setup setup;

    public FlightsController(ILogger<FlightsController> logger, Setup s)
    {
      setup = s;
      _logger = logger;
    }

    [HttpGet(Name = "GetFlights")]
    public List<Flight> Get()
    {
      return setup.Flights;
    }

    [HttpPost]
    public  ActionResult Post([FromBody]JsonObject newFlightJson)
    {
      return Ok(newFlightJson);
    }
  }
}