namespace AircraftParkingPlanning.Model
{
  public class ParkingSpot
  {
    public ParkingSpot(string name, double footprintSqm)
    {
      this.Name = name;
      this.FootprintSqm= footprintSqm;
    }
    public string Name { get; set; }
    public double FootprintSqm { get; set; }

  }
}
