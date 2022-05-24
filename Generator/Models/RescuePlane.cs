namespace Generator.Models
{
  public class RescuePlane : Airplane
  {
    public RescuePlane(AirplaneInfo info) : base(info)
    {
    }

    private RescuePlane()
    {
    }

    public override AirplaneType Type => AirplaneType.Rescue;
  }
}