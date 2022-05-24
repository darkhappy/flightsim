using System;

namespace Generator.Models
{
  public class AirplaneInfo : ObjectInfo
  {
    private int _maintenanceTime;
    private int _speed;

    public AirplaneInfo(string id, string name, AirplaneType type, int speed, int maintenanceTime) : base(id, name)
    {
      Type = type;
      MaintenanceTime = maintenanceTime;
      Speed = speed;
    }

    public AirplaneType Type { get; set; }

    public int MaintenanceTime
    {
      get => _maintenanceTime;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _maintenanceTime = value;
      }
    }

    public int Speed
    {
      get => _speed;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _speed = value;
      }
    }

    public virtual double MaxCapacity
    {
      get => 0;
      set { }
    }

    public virtual int EmbarkingTime
    {
      get => 0;
      set { }
    }

    public virtual int DisembarkingTime
    {
      get => 0;
      set { }
    }
  }
}