using System.Runtime.Serialization;

namespace Generator.Models
{
  [DataContract(Namespace = "")]
  public class PassengerPlane : TransportPlane
  {
    public PassengerPlane(AirplaneInfo info) : base(info)
    {
    }

    public override AirplaneType Type => AirplaneType.Passenger;
  }
}