using System.Runtime.Serialization;

namespace Generator.Models
{
  [DataContract]
  public class CargoPlane : TransportPlane
  {
    public CargoPlane(AirplaneInfo info) : base(info)
    {
    }

    public override AirplaneType Type => AirplaneType.Cargo;
  }
}