using System.Runtime.Serialization;

namespace Generator.Models
{
  /// <summary>
  ///   Represents a plane that transports passengers.
  /// </summary>
  [DataContract(Namespace = "")]
  public class PassengerPlane : TransportPlane
  {
    /// <summary>
    ///   Constructor for the <see cref="PassengerPlane" /> class.
    /// </summary>
    /// <param name="info">The information needed to create an the <see cref="PassengerPlane"/></param>
    public PassengerPlane(AirplaneInfo info) : base(info)
    {
    }

    /// <summary>
    ///   Represents the type of <see cref="PassengerPlane" />.
    /// </summary>
    /// <seealso cref="AirplaneType" />
    public override AirplaneType Type => AirplaneType.Passenger;
  }
}