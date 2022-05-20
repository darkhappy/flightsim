namespace Generator.Models
{
  public abstract class TransportPlane : Airplane
  {
    protected TransportPlane(string id, string name, int speed, int maintenanceTime, Airport origin,
                             double maxCapacity, int embarkingTime, int disembarkingTime) : base(
      id, name, speed, maintenanceTime, origin)
    {
      MaxCapacity = maxCapacity;
      EmbarkingTime = embarkingTime;
      DisembarkingTime = disembarkingTime;
    }

    public double MaxCapacity { get; set; }
    public int EmbarkingTime { get; set; }
    public int DisembarkingTime { get; set; }
  }
}