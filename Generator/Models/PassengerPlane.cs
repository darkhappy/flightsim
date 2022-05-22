namespace Generator.Models
{
  public class PassengerPlane : TransportPlane
  {
    public PassengerPlane(AirplaneInfo info) : base(info)
    {
    }

    public override Colour Colour => Colour.Green;
    public override AirplaneType Type => AirplaneType.Passenger;
  }
}