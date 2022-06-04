using System.Runtime.Serialization;

namespace Generator.Models
{
  [DataContract(Namespace = "")]
  public class ScoutPlane : Airplane
  {
    /// <summary>
    ///   Constructor for the <see cref="ScoutPlane" /> class.
    /// </summary>
    /// <param name="info">The information needed to create an the <see cref="ScoutPlane"/></param>
    public ScoutPlane(AirplaneInfo info) : base(info)
    {
    }

    /// <summary>
    ///   Represents the type of <see cref="ScoutPlane" />.
    /// </summary>
    /// <seealso cref="AirplaneType" />
    public override AirplaneType Type => AirplaneType.Scout;
  }
}