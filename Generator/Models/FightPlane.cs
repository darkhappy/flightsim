using System.Runtime.Serialization;

namespace Generator.Models
{
  /// <summary>
  ///   Represents a plane that engages in fights.
  /// </summary>
  [DataContract(Namespace = "")]
  public class FightPlane : Airplane
  {
    /// <summary>
    ///   Constructor for the <see cref="FightPlane" /> class.
    /// </summary>
    /// <param name="info">The information needed to create an the <see cref="FightPlane"/></param>
    public FightPlane(AirplaneInfo info) : base(info)
    {
    }

    /// <summary>
    ///   Represents the type of <see cref="FightPlane" />.
    /// </summary>
    /// <seealso cref="AirplaneType" />
    public override AirplaneType Type => AirplaneType.Fight;
  }
}