namespace Generator.Models
{
  public class FightPlane : Airplane
  {
    public FightPlane(string id, string name, int speed, int maintenanceTime) : base(
      id, name, speed, maintenanceTime)
    {
    }

    public override Colour Colour => Colour.Yellow;
    public override AirplaneType Type => AirplaneType.Fight; 
  }
}