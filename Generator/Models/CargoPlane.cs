namespace Generator.Models
{
  public class CargoPlane : TransportPlane
  {
    public CargoPlane(string id, string name, int speed, int maintenanceTime, Airport origin,
                            double maxCapacity, int embarkingTime, int disembarkingTime) : base(id, name,
      speed, maintenanceTime, origin, maxCapacity, embarkingTime, disembarkingTime)
    {
    }

    public override Colour Colour => Colour.Blue;
  }
}