namespace Generator.Models
{
  public class RescuePlane : Airplane
  {
    public RescuePlane(AirplaneInfo info) : base(info)
    {
    }

    public override Colour Colour => Colour.Red;
    public override AirplaneType Type => AirplaneType.Rescue;
  }
}