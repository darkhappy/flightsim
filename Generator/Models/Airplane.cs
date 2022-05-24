namespace Generator.Models
{
  public abstract class Airplane
  {
    protected Airplane(AirplaneInfo info)
    {
      Id = info.Id;
      Name = info.Name;
      Speed = info.Speed;
      MaintenanceTime = info.MaintenanceTime;
    }

    public string Id { get; private set; }

    public string Name { get; private set; }

    public int Speed { get; private set; }

    public int MaintenanceTime { get; private set; }

    public abstract AirplaneType Type { get; }

    public virtual void Edit(AirplaneInfo info)
    {
      Id = info.Id;
      Name = info.Name;
      Speed = info.Speed;
      MaintenanceTime = info.MaintenanceTime;
    }

    public AirplaneInfo ToAirplaneInfo()
    {
      return new AirplaneInfo(Id, Name, Type, Speed, MaintenanceTime);
    }
  }
}