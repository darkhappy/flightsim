namespace Generator.Models
{
  public class FightPlane : Airplane
  {
    public FightPlane(string id, string name, Position position, int speed, int maintenanceTime, Airport origin) : base(
      id, name, position, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Yellow;
  }
}