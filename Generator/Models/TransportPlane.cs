using System.Collections.Generic;

namespace Generator.Models
{
  public abstract class TransportPlane : Airplane
  {
    protected TransportPlane(string id, string name, int speed, int maintenanceTime,
                             double maxCapacity, int embarkingTime, int disembarkingTime) : base(
      id, name, speed, maintenanceTime)
    {
      MaxCapacity = maxCapacity;
      EmbarkingTime = embarkingTime;
      DisembarkingTime = disembarkingTime;
    }

    public override void Edit(Dictionary<string, object> data)
    {
      base.Edit(data);

      MaxCapacity = (double) data["maxCapacity"];
      EmbarkingTime = (int) data["embarkingTime"];
      DisembarkingTime = (int) data["disembarkingTime"];
    }

    public double MaxCapacity { get; private set; }
    public int EmbarkingTime { get; private set; }
    public int DisembarkingTime { get; private set; }
  }
}