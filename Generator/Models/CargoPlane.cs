using System.Runtime.Serialization;

namespace Generator.Models
{
  /// <summary>
  ///   Represents a plane that transports cargo.
  /// </summary>
  [DataContract(Namespace = "")]
  public class CargoPlane : TransportPlane
  {
    /// <summary>
    ///   Constructor for the <see cref="CargoPlane" /> class.
    /// </summary>
    /// <param name="info">The information needed to create an the <see cref="CargoPlane"/></param>
    public CargoPlane(AirplaneInfo info) : base(info)
    {
    }

    /// <summary>
    ///   Represents the type of <see cref="CargoPlane" />.
    /// </summary>
    /// <seealso cref="AirplaneType" />
    public override AirplaneType Type => AirplaneType.Cargo;
  }
}