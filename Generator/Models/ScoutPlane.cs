using System.Runtime.Serialization;

namespace Generator.Models
{
  [DataContract]
  public class ScoutPlane : Airplane
  {
    public ScoutPlane(AirplaneInfo info) : base(info)
    {
    }

    public override AirplaneType Type => AirplaneType.Scout;
  }
}