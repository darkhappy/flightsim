namespace Generator.Models
{
  public class AirportInfo : ObjectInfo
  {
    public AirportInfo(string id, string name, Position position, int passengerTraffic, double cargoTraffic) : base(id,
      name)
    {
      Position = position;
      PassengerTraffic = passengerTraffic;
      CargoTraffic = cargoTraffic;
    }

    public Position Position { get; set; }

    public int PassengerTraffic { get; set; }

    public double CargoTraffic { get; set; }
  }
}