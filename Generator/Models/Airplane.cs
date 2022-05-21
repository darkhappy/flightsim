using System.Collections.Generic;

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

    public string Id { get; private set; }

    public string Name { get; private set; }

    public int Speed { get; private set; }

    public int MaintenanceTime { get; private set; }

    public abstract Colour Colour { get; }
    public abstract AirplaneType Type { get; }

    public virtual void Edit(Dictionary<string, object> data)
    {
      if (!AirplaneFactory.Instance.VerifyData(data)) return;

      Id = (string) data["id"];
      Name = (string) data["name"];
      Speed = (int) data["speed"];
      MaintenanceTime = (int) data["maintenanceTime"];
    }
  }
}