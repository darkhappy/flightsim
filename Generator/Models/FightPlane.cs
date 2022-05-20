namespace Generator.Models
{
  public class FightPlane : Airplane
  {
    public FightPlane(string id, string name, int speed, int maintenanceTime, Airport origin) : base(
      id, name, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Yellow;
  }
}