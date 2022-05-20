using System;
using System.Collections.Generic;

namespace Generator.Models
{
  public class AirplaneFactory
  {
    private static AirplaneFactory? _instance;

    private AirplaneFactory()
    {
    }

    public static AirplaneFactory Instance => _instance ??= new AirplaneFactory();

    public Airplane CreateAirplane(Dictionary<string, object> data)
    {
      // Verify if any of the required fields is missing
      if (!data.ContainsKey("id") || !data.ContainsKey("name") || !data.ContainsKey("speed") ||
          !data.ContainsKey("type") || !data.ContainsKey("maintenanceTime"))
      {
        throw new ArgumentException("Invalid data");
      }


      // Get all the information
      var id = (string) data["id"];
      var name = (string) data["name"];
      var speed = (int) data["speed"];
      var type = (AirplaneType) data["type"];
      var maintenanceTime = (int) data["maintenanceTime"];

      var maxCapacity = data.ContainsKey("maxCapacity") ? (double) data["maxCapacity"] : 0;
      var embarkingTime = data.ContainsKey("embarkingTime") ? (int) data["embarkingTime"] : 0;
      var disembarkingTime = data.ContainsKey("embarkingTime") ? (int) data["disembarkingTime"] : 0;

      // Create the airplane
      return type switch
      {
        AirplaneType.Fight => new FightPlane(id, name, speed, maintenanceTime),
        AirplaneType.Cargo => new CargoPlane(id, name, speed, maintenanceTime, maxCapacity, embarkingTime,
          disembarkingTime),
        AirplaneType.Passenger => new PassengerPlane(id, name, speed, maintenanceTime, maxCapacity, embarkingTime,
          disembarkingTime),
        AirplaneType.Rescue => new RescuePlane(id, name, speed, maintenanceTime),
        AirplaneType.Scout => new ScoutPlane(id, name, speed, maintenanceTime),
        _ => throw new ArgumentOutOfRangeException()
      };
    }
  }
}