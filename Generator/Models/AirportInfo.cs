namespace Generator.Models
{
  public class AirportInfo : ObjectInfo
  {
    public AirportInfo(string id, string name, Position position, int passengerTraffic, double cargoTraffic) : base(id,
      name)
    {
      Position = position;
      PassengerTraffic = passengerTraffic;
      CargoTraffic = cargoTraffic;
    }

    public Position Position { get; set; }

    public int PassengerTraffic { get; set; }

    public double CargoTraffic { get; set; }

    protected bool Equals(AirportInfo other)
    {
      return base.Equals(other) && Position.Equals(other.Position) && PassengerTraffic == other.PassengerTraffic &&
             CargoTraffic.Equals(other.CargoTraffic);
    }

    public override bool Equals(object? obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((AirportInfo) obj);
    }

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

    public static bool operator ==(AirportInfo? left, AirportInfo? right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(AirportInfo? left, AirportInfo? right)
    {
      return !Equals(left, right);
    }
  }
}