namespace Generator.Models
{
  public class RescuePlane : Airplane
  {
    public RescuePlane(string id, string name, int speed, int maintenanceTime, Airport origin) :
      base(id, name, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Red;
  }
}