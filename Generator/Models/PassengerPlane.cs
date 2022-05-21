namespace Generator.Models
{
  public class PassengerPlane : TransportPlane
  {
    public PassengerPlane(string id, string name, int speed, int maintenanceTime,
                          double maxCapacity, int embarkingTime, int disembarkingTime) : base(id, name, speed,
      maintenanceTime, maxCapacity, embarkingTime, disembarkingTime)
    {
    }

    public override Colour Colour => Colour.Green;
    public override AirplaneType Type => AirplaneType.Passenger;
  }
}