namespace Generator.Models
{
  public class ScoutPlane : Airplane
  {
    public ScoutPlane(string id, string name, Position position, int speed, int maintenanceTime, Airport origin) : base(
      id, name, position, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Gray;
  }
}