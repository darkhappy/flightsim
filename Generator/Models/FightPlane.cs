namespace Generator.Models
{
  public class FightPlane : Airplane
  {
    public FightPlane(AirplaneInfo info) : base(info)
    {
    }

    /// <summary>
    ///   Only used for serialization.
    /// </summary>
    private FightPlane()
    {
    }

    public override AirplaneType Type => AirplaneType.Fight;
  }
}