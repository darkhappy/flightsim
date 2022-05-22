namespace Generator.Models
{
  public class FightPlane : Airplane
  {
    public FightPlane(AirplaneInfo info) : base(info)
    {
    }

    public override AirplaneType Type => AirplaneType.Fight;
  }
}