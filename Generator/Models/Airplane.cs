namespace Generator.Models
{
  public abstract class Airplane
  {
    protected Airplane(string id, string name, int speed, int maintenanceTime)
    {
      Id = id;
      Name = name;
      Speed = speed;
      MaintenanceTime = maintenanceTime;
    }

    public string Id { get; set; }

    public string Name { get; set; }

    public int Speed { get; set; }

    public int MaintenanceTime { get; set; }

    public abstract Colour Colour { get; }
  }
}