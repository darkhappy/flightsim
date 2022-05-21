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
      if (!VerifyData(data))
      {
        throw new ArgumentException("Invalid data");
      }

      // Get all the information
      var id = (string) data["id"];
      var name = (string) data["name"];
      var speed = (int) data["speed"];
      var type = (AirplaneType) data["type"];
      var maintenanceTime = (int) data["maintenanceTime"];

      double maxCapacity = 0;
      var embarkingTime = 0;
      var disembarkingTime = 0;

      if (type == AirplaneType.Passenger || type == AirplaneType.Cargo)
      {
        maxCapacity = (double) data["maxCapacity"];
        embarkingTime = (int) data["embarkingTime"];
        disembarkingTime = (int) data["disembarkingTime"];
      }

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

    public bool VerifyData(Dictionary<string, object> data)
    {
      // Verify if the data is present
      if (!data.ContainsKey("id") || !data.ContainsKey("name") || !data.ContainsKey("speed") ||
          !data.ContainsKey("type") || !data.ContainsKey("maintenanceTime"))
        return false;

      // Verify each object's type
      if (!(data["id"] is string) || !(data["name"] is string) || !(data["speed"] is int) ||
          !(data["type"] is AirplaneType) || !(data["maintenanceTime"] is int))
        return false;

      var type = (AirplaneType) data["type"];

      // Transport information
      if (type != AirplaneType.Cargo && type != AirplaneType.Passenger) return true;

      // Verify if the data is present
      if (!data.ContainsKey("maxCapacity") || !data.ContainsKey("embarkingTime") ||
          !data.ContainsKey("disembarkingTime"))
        return false;

      return data["maxCapacity"] is double && data["embarkingTime"] is int &&
             data["disembarkingTime"] is int;
    }
  }
}