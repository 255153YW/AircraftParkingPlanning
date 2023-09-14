using AircraftParkingPlanning.Model;
using System.IO;
using System.Xml.Linq;

namespace AircraftParkingPlanning
{
  public class Setup
  {
    public List<Flight> Flights { get; set; }
    public List<Aircraft> AircraftList { get; set; }

    public List<ParkingArea> ParkingAreas { get; set; }
    public Setup()
    {
      CreateAirport();
      CreateAircaftList();
      CreateFlights();
    }

    private void CreateFlights()
    {
      Flights = new List<Flight>
      {
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("PHNXT"),
          StartDateTime = DateTime.Parse("1 Jan 2023 12:00"),
          EndDateTime = DateTime.Parse("2 Jan 2023 08:00"),
          ParkingSpot = ParkingSpot("N1")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("PHNXT"),
          StartDateTime = DateTime.Parse("1 Jan 2023 12:00"),
          EndDateTime = DateTime.Parse("2 Jan 2023 08:30"),
          ParkingSpot = ParkingSpot("N1")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("9HLTT"),
          StartDateTime = DateTime.Parse("1 Jan 2023 10:00"),
          EndDateTime = DateTime.Parse("3 Jan 2023 12:00"),
          ParkingSpot = ParkingSpot("N2")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("YUPRJ"),
          StartDateTime = DateTime.Parse("2 Jan 2023 08:30"),
          EndDateTime = DateTime.Parse("3 Jan 2023 12:00"),
          ParkingSpot = ParkingSpot("N1")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("N123T"),
          StartDateTime = DateTime.Parse("1 Jan 2023 14:30"),
          EndDateTime = DateTime.Parse("1 Jan 2023 20:00"),
          ParkingSpot = ParkingSpot("S1")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("NCDFT"),
          StartDateTime = DateTime.Parse("1 Jan 2023 09:30"),
          EndDateTime = DateTime.Parse("4 Jan 2023 09:00"),
          ParkingSpot = ParkingSpot("S2")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("PHNXT"),
          StartDateTime = DateTime.Parse("3 Jan 2023 13:00"),
          EndDateTime = DateTime.Parse("4 Jan 2023 15:00"),
          ParkingSpot = ParkingSpot("N1")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("ERZ2"),
          StartDateTime = DateTime.Parse("2 Jan 2023 09:30"),
          EndDateTime = DateTime.Parse("3 Jan 2023 09:00"),
          ParkingSpot = ParkingSpot("S3")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("ERZ2"),
          StartDateTime = DateTime.Parse("5 Jan 2023 09:30"),
          EndDateTime = DateTime.Parse("5 Jan 2023 19:00"),
          ParkingSpot = ParkingSpot("S3")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("ERZ2"),
          StartDateTime = DateTime.Parse("1 Jan 2023 23:30"),
          EndDateTime = DateTime.Parse("2 Jan 2023 00:30"),
          ParkingSpot = ParkingSpot("S3")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("ERZ2"),
          StartDateTime = DateTime.Parse("1 Jan 2023 00:30"),
          EndDateTime = DateTime.Parse("1 Jan 2023 01:30"),
          ParkingSpot = ParkingSpot("S3")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("ERZ1"),
          StartDateTime = DateTime.Parse("1 Jan 2023 00:00"),
          EndDateTime = DateTime.Parse("1 Jan 2023 00:30"),
          ParkingSpot = ParkingSpot("N3")
        },
        new Flight(Guid.NewGuid().ToString())
        {
          Aircraft = Aircraft("ERZ2"),
          StartDateTime = DateTime.Parse("1 Jan 2023 00:30"),
          EndDateTime = DateTime.Parse("1 Jan 2023 02:30"),
          ParkingSpot = ParkingSpot("N3")
        }
      };
    }

    private void CreateAirport()
    {
      ParkingAreas = new List<ParkingArea>
      {
        new ParkingArea
        {
          Name = "North",
          ParkingSpots = new List<ParkingSpot>
          {
            new ParkingSpot("N1",700),
            new ParkingSpot("N2", 700),
            new ParkingSpot("N3", 1400),
            new ParkingSpot("N4", 1000),
            new ParkingSpot("N5", 1000),
            new ParkingSpot("N6", 1500),
          }
        },
        new ParkingArea
        {
          Name = "South",
          ParkingSpots = new List<ParkingSpot>
          {
            new ParkingSpot("S1", 700),
            new ParkingSpot("S2", 700),
            new ParkingSpot("S3", 1400),
            new ParkingSpot("S4", 1000),
            new ParkingSpot("S5", 1000),
            new ParkingSpot("S6", 1500),
            new ParkingSpot("S7", 4500),
          }
        },
      };
    }

    private ParkingSpot ParkingSpot(string name)
    {
      return ParkingAreas.SelectMany(a => a.ParkingSpots).Where(a => a.Name == name).Single();
    }

    private void CreateAircaftList()
    {
      AircraftList = new List<Aircraft>
      {
        new Aircraft {RegistrationCode = "PHNXT", FootprintSqm = 350, AircraftType = "Piper 350" },
        new Aircraft {RegistrationCode = "9HLTT", FootprintSqm = 600, AircraftType = "Aero-600" },
        new Aircraft {RegistrationCode = "YUPRJ", FootprintSqm = 420, AircraftType = "Super 420" },
        new Aircraft {RegistrationCode = "N123T", FootprintSqm = 550, AircraftType = "G550"},
        new Aircraft {RegistrationCode = "NCDFT", FootprintSqm = 780, AircraftType = "780 Special" },
        new Aircraft {RegistrationCode = "TTPB", FootprintSqm = 490, AircraftType = "Type 490" },
        new Aircraft {RegistrationCode = "ZZZZ", FootprintSqm = 1000, AircraftType = "Type 1000" },
        new Aircraft {RegistrationCode = "ERZ1", FootprintSqm = 1000, AircraftType = "B1000" },
        new Aircraft {RegistrationCode = "ERZ2", FootprintSqm = 3000, AircraftType = "A3000-MAX" },
      };
    }

    private Aircraft Aircraft(string registrationCode)
    {
      return AircraftList.Single(a => a.RegistrationCode == registrationCode);
    }

    public void addFlight(Flight newFlight)
    {
      this.Flights.Add(newFlight);
    }

    public Aircraft? getAircraftByRegistration(string registrationCode)
    {
      return AircraftList.SingleOrDefault(a => a.RegistrationCode == registrationCode);
    }

    public Flight? getFlightById(string id)
    {
      return Flights.SingleOrDefault(f => f.Id == id);
    }

    public void removeFlight(string flightIdToRemove)
    {
      int flightIndexToDelete = this.Flights.FindIndex(flight => flight.Id.Contains(flightIdToRemove));
      if(flightIndexToDelete >= 0)
      {
        this.Flights.RemoveAt(flightIndexToDelete);
      }
      
    }
  }
}
