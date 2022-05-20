namespace Generator.Models
{
  public class ScoutPlane : Airplane
  {
    public ScoutPlane(string id, string name, int speed, int maintenanceTime, Airport origin) : base(
      id, name, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Gray;
  }
}