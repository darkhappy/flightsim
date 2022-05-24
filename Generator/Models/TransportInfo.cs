using System;

namespace Generator.Models
{
  public class TransportInfo : AirplaneInfo
  {
    private int _disembarkingTime;
    private int _embarkingTime;
    private double _maxCapacity;

    public TransportInfo(string id, string name, AirplaneType type, int speed, int maintenanceTime, double maxCapacity,
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

    protected bool Equals(TransportInfo other)
    {
      return base.Equals(other) && _disembarkingTime == other._disembarkingTime &&
             _embarkingTime == other._embarkingTime && _maxCapacity.Equals(other._maxCapacity);
    }

    public override bool Equals(object? obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((TransportInfo) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        var hashCode = base.GetHashCode();
        hashCode = (hashCode * 397) ^ _disembarkingTime;
        hashCode = (hashCode * 397) ^ _embarkingTime;
        hashCode = (hashCode * 397) ^ _maxCapacity.GetHashCode();
        return hashCode;
      }
    }

    public static bool operator ==(TransportInfo? left, TransportInfo? right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(TransportInfo? left, TransportInfo? right)
    {
      return !Equals(left, right);
    }
  }
}