using System.Runtime.Serialization;

namespace Generator.Models
{
  [DataContract]
  public class RescuePlane : Airplane
  {
    public RescuePlane(AirplaneInfo info) : base(info)
    {
    }

    public override AirplaneType Type => AirplaneType.Rescue;
  }
}