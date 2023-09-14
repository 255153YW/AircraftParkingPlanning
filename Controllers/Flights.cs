using AircraftParkingPlanning.Model;
using Microsoft.AspNetCore.Mvc;

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
    public ActionResult Post([FromBody] Flight incomingFlightValues)
    {
      if (incomingFlightValues != null)
      {
        if(incomingFlightValues.Aircraft != null && incomingFlightValues.ParkingSpot != null)
        {
          string? registrationCode = incomingFlightValues.Aircraft.RegistrationCode;
          
          if (registrationCode != null) {
            Aircraft? existingAircraft = setup.getAircraftByRegistration(registrationCode);
            if(existingAircraft != null)
            {
              existingAircraft.AircraftType = incomingFlightValues.Aircraft.AircraftType;
              existingAircraft.FootprintSqm = incomingFlightValues.Aircraft.FootprintSqm;
            }
            else
            {
              setup.AircraftList.Add(incomingFlightValues.Aircraft);
            }
          }
          else
          {
            setup.AircraftList.Add(incomingFlightValues.Aircraft);
          }

          Flight? existingFlight = setup.getFlightById(incomingFlightValues.Id);
          if ( existingFlight != null)
          {
            existingFlight.Aircraft = incomingFlightValues.Aircraft;
            existingFlight.StartDateTime = incomingFlightValues.StartDateTime;
            existingFlight.EndDateTime = incomingFlightValues.EndDateTime;
            existingFlight.ParkingSpot = incomingFlightValues.ParkingSpot;
          }
          else
          {
            Flight newFlight = new Flight(Guid.NewGuid().ToString())
            {
              Aircraft = incomingFlightValues.Aircraft,
              StartDateTime = incomingFlightValues.StartDateTime,
              EndDateTime = incomingFlightValues.EndDateTime,
              ParkingSpot = incomingFlightValues.ParkingSpot
            };
            setup.addFlight(newFlight);
          }
        }
      }
      return Ok();
    }

    [HttpDelete("{id}")]
    public ActionResult Delete(string id)
    {
      if (setup.getFlightById(id) != null)
      {
        setup.removeFlight(id);
      }
      
      return Ok();
    }
  }
}