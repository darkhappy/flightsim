using System;
using System.Runtime.Serialization;

namespace Generator.Models
{
  [DataContract(Namespace = "")]
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

    [DataMember] public double MaxCapacity { get; private set; }
    [DataMember] public int EmbarkingTime { get; private set; }
    [DataMember] public int DisembarkingTime { get; private set; }

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