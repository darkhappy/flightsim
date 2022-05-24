using System;

namespace Generator.Models
{
  public abstract class TransportPlane : Airplane
  {
    protected TransportPlane(AirplaneInfo info) : base(info)
    {
      if (info.MaxCapacity <= 0)
        throw new ArgumentOutOfRangeException(nameof(info.MaxCapacity),
          @"Max capacity cannot be less than or equal to 0");

      MaxCapacity = info.MaxCapacity;
      EmbarkingTime = info.EmbarkingTime;
      DisembarkingTime = info.DisembarkingTime;
    }

    protected TransportPlane()
    {
    }

    public double MaxCapacity { get; set; }
    public int EmbarkingTime { get; set; }
    public int DisembarkingTime { get; set; }

    public override void Edit(AirplaneInfo data)
    {
      base.Edit(data);

      var info = (TransportInfo) data;

      MaxCapacity = info.MaxCapacity;
      EmbarkingTime = info.EmbarkingTime;
      DisembarkingTime = info.DisembarkingTime;
    }

    public override AirplaneInfo ToAirplaneInfo()
    {
      return new TransportInfo(Id, Name, Type, Speed, MaintenanceTime, MaxCapacity, EmbarkingTime, DisembarkingTime);
    }
  }
}