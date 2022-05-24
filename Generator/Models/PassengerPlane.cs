namespace Generator.Models
{
  public class PassengerPlane : TransportPlane
  {
    public PassengerPlane(AirplaneInfo info) : base(info)
    {
    }

    private PassengerPlane()
    {
    }

    public override AirplaneType Type => AirplaneType.Passenger;
  }
}