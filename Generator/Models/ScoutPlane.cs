namespace Generator.Models
{
  public class ScoutPlane : Airplane
  {
    public ScoutPlane(AirplaneInfo info) : base(info)
    {
    }

    /// <summary>
    ///   Used for serialization.
    /// </summary>
    internal ScoutPlane()
    {
    }

    public override AirplaneType Type => AirplaneType.Scout;
  }
}