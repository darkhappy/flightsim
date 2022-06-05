namespace Generator.Models
{
  /// <summary>
  ///   Class representing the <see cref="AirportInfo"/> of a <see cref="Airport"/> in the simulation.
  /// </summary>
  public class AirportInfo : ObjectInfo
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="AirportInfo" /> class.
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Airport"/>.</param>
    /// <param name="name">The name of the <see cref="Airport"/>.</param>
    /// <param name="position">The <see cref="Position"/> of the <see cref="Airport"/>.</param>
    /// <param name="passengerTraffic">The passenger traffic of the <see cref="Airport"/>.</param>
    /// <param name="cargoTraffic">The cargo traffic of the <see cref="Airport"/>.</param>
    public AirportInfo(string id, string name, Position position, int passengerTraffic, double cargoTraffic) : base(id,
      name)
    {
      Position = position;
      PassengerTraffic = passengerTraffic;
      CargoTraffic = cargoTraffic;
    }

    /// <summary>
    ///   Represents the <see cref="Position"/> of the <see cref="Airport" />
    /// </summary>
    /// <inheritdoc cref="Airport.Position" />
    public Position Position { get; set; }

    /// <summary>
    ///   Represents the passenger traffic of the <see cref="Airport" />
    /// </summary>
    /// <inheritdoc cref="Airport.PassengerTraffic" />
    public int PassengerTraffic { get; set; }

    /// <summary>
    ///   Represents the cargo traffic of the <see cref="Airport" />
    /// </summary>
    /// <inheritdoc cref="Airport.CargoTraffic" />
    public double CargoTraffic { get; set; }

    /// <summary>
    ///   Determines if two <see cref="AirportInfo"/> are equal
    /// </summary>
    /// <param name="other">The <see cref="AirportInfo"/> that will be compared to the actual object</param>
    /// <returns>Whether the two object are equal</returns>
    protected bool Equals(AirportInfo other)
    {
      return base.Equals(other) && Position.Equals(other.Position) && PassengerTraffic == other.PassengerTraffic &&
             CargoTraffic.Equals(other.CargoTraffic);
    }

    /// <summary>
    ///   Determines if the current <see cref="AirportInfo"/> is equal to another object
    /// </summary>
    /// <param name="obj">The object that will be compared to the actual object</param>
    /// <returns>Whether the two object are equal</returns>
    public override bool Equals(object? obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((AirportInfo) obj);
    }

    /// <summary>
    ///   Represents the HashCode for the <see cref="AirportInfo"/> usefull for Equals().
    /// </summary>
    public override int GetHashCode()
    {
      unchecked
      {
        var hashCode = base.GetHashCode();
        hashCode = (hashCode * 397) ^ Position.GetHashCode();
        hashCode = (hashCode * 397) ^ PassengerTraffic;
        hashCode = (hashCode * 397) ^ CargoTraffic.GetHashCode();
        return hashCode;
      }
    }

    /// <summary>
    ///   Check if two <see cref="AirportInfo"/> are equal
    /// </summary>
    /// <param name="left">The first <see cref="AirportInfo"/> compared</param>
    /// <param name="right">The second <see cref="AirportInfo"/> compared</param>
    /// <returns>Whether the two object are equal</returns>
    public static bool operator ==(AirportInfo? left, AirportInfo? right)
    {
      return Equals(left, right);
    }

    /// <summary>
    ///   Check if two <see cref="AirportInfo"/> are equal
    /// </summary>
    /// <param name="left">The first <see cref="AirportInfo"/> compared</param>
    /// <param name="right">The second <see cref="AirportInfo"/> compared</param>
    /// <returns>Whether the two object are equal</returns>
    public static bool operator !=(AirportInfo? left, AirportInfo? right)
    {
      return !Equals(left, right);
    }
  }
}