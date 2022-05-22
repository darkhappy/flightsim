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
      var type = data.Type;

      return type switch
      {
        AirplaneType.Cargo => new CargoPlane(data),
        AirplaneType.Passenger => new PassengerPlane(data),
        AirplaneType.Fight => new FightPlane(data),
        AirplaneType.Rescue => new RescuePlane(data),
        AirplaneType.Scout => new ScoutPlane(data),
        _ => throw new NotSupportedException("Airplane type is not supported.")
      };
    }
  }
}