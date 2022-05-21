using System;

namespace Generator.Models
{
  public class AirplaneFactory
  {
    private static AirplaneFactory? _instance;

    private AirplaneFactory()
    {
    }

    public static AirplaneFactory Instance => _instance ??= new AirplaneFactory();

    public Airplane CreateAirplane(AirplaneInfo data)
    {
      var id = data.Id;
      var name = data.Name;
      var speed = data.Speed;
      var type = data.Type;
      var maintenanceTime = data.MaintenanceTime;
      var maxCapacity = data.MaxCapacity;
      var embarkingTime = data.EmbarkingTime;
      var disembarkingTime = data.DisembarkingTime;

      return type switch
      {
        AirplaneType.Cargo => new CargoPlane(id, name, speed, maintenanceTime, maxCapacity, embarkingTime,
          disembarkingTime),
        AirplaneType.Passenger => new PassengerPlane(id, name, speed, maintenanceTime, maxCapacity, embarkingTime,
          disembarkingTime),
        AirplaneType.Fight => new FightPlane(id, name, speed, maintenanceTime),
        AirplaneType.Rescue => new RescuePlane(id, name, speed, maintenanceTime),
        AirplaneType.Scout => new ScoutPlane(id, name, speed, maintenanceTime),
        _ => throw new ArgumentOutOfRangeException()
      };
    }
  }
}