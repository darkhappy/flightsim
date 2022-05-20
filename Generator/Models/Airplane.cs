namespace Generator.Models
{
  public abstract class Airplane
  {
    protected Airplane(string id, string name, int speed, int maintenanceTime, Airport origin)
    {
      Id = id;
      Name = name;
      Speed = speed;
      MaintenanceTime = maintenanceTime;
      Origin = origin;
    }

    public string Id { get; set; }

    public string Name { get; set; }

    public int Speed { get; set; }

    public int MaintenanceTime { get; set; }

    public Airport Origin { get; set; }

    public abstract Colour Colour { get; }
  }
}