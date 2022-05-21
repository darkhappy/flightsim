using System;

namespace Generator.Models
{
  public abstract class TransportPlane : Airplane
  {
    protected TransportPlane(string id, string name, int speed, int maintenanceTime,
                             double maxCapacity, int embarkingTime, int disembarkingTime) : base(
      id, name, speed, maintenanceTime)
    {
      if (maxCapacity <= 0) throw new ArgumentException("Max capacity cannot be less than or equal to 0");

      MaxCapacity = maxCapacity;
      EmbarkingTime = embarkingTime;
      DisembarkingTime = disembarkingTime;
    }

    public double MaxCapacity { get; private set; }
    public int EmbarkingTime { get; private set; }
    public int DisembarkingTime { get; private set; }

    public override void Edit(AirplaneInfo data)
    {
      base.Edit(data);

      var info = (TransportInfo) data;

      MaxCapacity = info.MaxCapacity;
      EmbarkingTime = info.EmbarkingTime;
      DisembarkingTime = info.DisembarkingTime;
    }
  }
}