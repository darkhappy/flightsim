namespace Generator.Models
{
  public class CargoPlane : TransportPlane
  {
    public CargoPlane(string id, string name, int speed, int maintenanceTime,
                      double maxCapacity, int embarkingTime, int disembarkingTime) : base(id, name,
      speed, maintenanceTime, maxCapacity, embarkingTime, disembarkingTime)
    {
    }

    public override Colour Colour => Colour.Blue;
    public override AirplaneType Type => AirplaneType.Cargo; 
  }
}