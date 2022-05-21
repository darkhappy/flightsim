using System;

namespace Generator.Models
{
  public class TransportInfo : AirplaneInfo
  {
    private int _disembarkingTime;
    private int _embarkingTime;
    private double _maxCapacity;

    public TransportInfo(string id, string name, AirplaneType type, int maintenanceTime, int speed, double maxCapacity,
                         int embarkingTime, int disembarkingTime) : base(id, name, type, speed, maintenanceTime)
    {
      if (type != AirplaneType.Passenger && type != AirplaneType.Cargo)
        throw new ArgumentException("Invalid type");

      MaxCapacity = maxCapacity;
      EmbarkingTime = embarkingTime;
      DisembarkingTime = disembarkingTime;
    }

    public sealed override double MaxCapacity
    {
      get => _maxCapacity;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _maxCapacity = value;
      }
    }

    public sealed override int EmbarkingTime
    {
      get => _embarkingTime;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _embarkingTime = value;
      }
    }

    public sealed override int DisembarkingTime
    {
      get => _disembarkingTime;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _disembarkingTime = value;
      }
    }
  }
}