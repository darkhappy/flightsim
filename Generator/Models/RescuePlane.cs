namespace Generator.Models
{
  public class RescuePlane : Airplane
  {
    public RescuePlane(string id, string name, int speed, int maintenanceTime) :
      base(id, name, speed, maintenanceTime)
    {
    }

    public override Colour Colour => Colour.Red;
    public override AirplaneType Type => AirplaneType.Rescue;
  }
}