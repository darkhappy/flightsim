using System.Runtime.Serialization;

namespace Generator.Models
{
  /// <summary>
  ///   Represents a plane that rescues people.
  /// </summary>
  [DataContract(Namespace = "")]
  public class RescuePlane : Airplane
  {
    /// <summary>
    ///   Constructor for the <see cref="RescuePlane" /> class.
    /// </summary>
    /// <param name="info">The information needed to create an the <see cref="RescuePlane"/></param>
    public RescuePlane(AirplaneInfo info) : base(info)
    {
    }

    /// <summary>
    ///   Represents the type of <see cref="RescuePlane" />.
    /// </summary>
    /// <seealso cref="AirplaneType" />
    public override AirplaneType Type => AirplaneType.Rescue;
  }
}