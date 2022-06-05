using System;

namespace Generator.Models
{
  /// <summary>
  ///   Class representing the <see cref="TransportInfo"/> of a <see cref="TransportPlane"/> in the simulation,
  ///   representing either a <see cref="PassengerPlane"/> or a <see cref="CargoPlane"/>
  /// </summary>
  public class TransportInfo : AirplaneInfo
  {
    /// <inheritdoc cref="TransportPlane.DisembarkingTime"/>
    private int _disembarkingTime;

    /// <inheritdoc cref="TransportPlane.EmbarkingTime"/>
    private int _embarkingTime;

    /// <inheritdoc cref="TransportPlane.MaxCapacity"/>
    private double _maxCapacity;

    /// <summary>
    ///   Initializes a new instance of the <see cref="TransportInfo" /> class.
    /// </summary>
    /// <param name="id">The unique identifier of a <see cref="TransportPlane"/></param>
    /// <param name="name">The name of a <see cref="TransportPlane"/></param>
    /// <param name="type">The <see cref="AirplaneType"/> of a <see cref="TransportPlane"/></param>
    /// <param name="speed">The speed of a <see cref="TransportPlane"/></param>
    /// <param name="maintenanceTime">The maintenance of a <see cref="TransportPlane"/></param>
    /// <param name="maxCapacity">The maximum transport capacity of a <see cref="TransportPlane"/></param>
    /// <param name="embarkingTime">The embarking time of a <see cref="TransportPlane"/></param>
    /// <param name="disembarkingTime">The disembarking of a <see cref="TransportPlane"/></param>
    /// <exception cref="ArgumentException">Invalid <see cref="AirplaneType"/></exception>
    public TransportInfo(string id, string name, AirplaneType type, int speed, int maintenanceTime, double maxCapacity,
                         int embarkingTime, int disembarkingTime) : base(id, name, type, speed, maintenanceTime)
    {
      if (type != AirplaneType.Passenger && type != AirplaneType.Cargo)
        throw new ArgumentException("Invalid type");

      MaxCapacity = maxCapacity;
      EmbarkingTime = embarkingTime;
      DisembarkingTime = disembarkingTime;
    }

    /// <summary>
    ///   Represents the maximum capacity for the <see cref="TransportInfo" />.
    /// </summary>
    public sealed override double MaxCapacity
    {
      get => _maxCapacity;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _maxCapacity = value;
      }
    }

    /// <summary>
    ///   Represents the embarking time for the <see cref="TransportInfo" />.
    /// </summary>
    public sealed override int EmbarkingTime
    {
      get => _embarkingTime;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _embarkingTime = value;
      }
    }

    /// <summary>
    ///   Represents the disembarking time for the <see cref="TransportInfo" />.
    /// </summary>
    public sealed override int DisembarkingTime
    {
      get => _disembarkingTime;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _disembarkingTime = value;
      }
    }

    /// <summary>
    ///   Determines if two <see cref="TransportInfo"/> are equal
    /// </summary>
    /// <param name="other">The <see cref="TransportInfo"/> that will be compared to the actual object</param>
    /// <returns>Whether the two object are equal</returns>
    protected bool Equals(TransportInfo other)
    {
      return base.Equals(other) && _disembarkingTime == other._disembarkingTime &&
             _embarkingTime == other._embarkingTime && _maxCapacity.Equals(other._maxCapacity);
    }

    /// <summary>
    ///   Determines if the current <see cref="TransportInfo"/> is equal to another object
    /// </summary>
    /// <param name="obj">The object that will be compared to the actual object</param>
    /// <returns>Whether the two object are equal</returns>
    public override bool Equals(object? obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((TransportInfo) obj);
    }

    /// <summary>
    ///   Represents the HashCode for the <see cref="TransportInfo"/> usefull for Equals().
    /// </summary>
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

    /// <summary>
    ///   Check if two <see cref="TransportInfo"/> are equal
    /// </summary>
    /// <param name="left">The first <see cref="TransportInfo"/> compared</param>
    /// <param name="right">The second <see cref="TransportInfo"/> compared</param>
    /// <returns>Whether the two object are equal</returns>
    public static bool operator ==(TransportInfo? left, TransportInfo? right)
    {
      return Equals(left, right);
    }

    /// <summary>
    ///   Check if two <see cref="TransportInfo"/> are not equal
    /// </summary>
    /// <param name="left">The first <see cref="TransportInfo"/> compared</param>
    /// <param name="right">The second <see cref="TransportInfo"/> compared</param>
    /// <returns>Whether the two object are not equal</returns>
    public static bool operator !=(TransportInfo? left, TransportInfo? right)
    {
      return !Equals(left, right);
    }
  }
}