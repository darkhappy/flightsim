namespace Generator.Models
{
  public class ScoutPlane : Airplane
  {
    public ScoutPlane(string id, string name, int speed, int maintenanceTime) : base(
      id, name, speed, maintenanceTime)
    {
    }

    public override Colour Colour => Colour.Gray;
    public override AirplaneType Type => AirplaneType.Scout;
  }
}