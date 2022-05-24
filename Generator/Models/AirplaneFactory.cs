using System;

namespace Generator.Models
{
  /// <summary>
  ///   Factory for creating <see cref="Airplane" /> objects.
  /// </summary>
  public class AirplaneFactory
  {
    /// <summary>
    ///   The instance of the <see cref="AirplaneFactory" />
    /// </summary>
    private static AirplaneFactory? _instance;

    /// <summary>
    ///   Constructor for the <see cref="AirplaneFactory" />.
    ///   <remarks>
    ///     It is private to prevent instantiation, and to ensure that the <see cref="AirplaneFactory" /> is a singleton.
    ///   </remarks>
    /// </summary>
    private AirplaneFactory()
    {
    }

    /// <summary>
    ///   Gets the instance of the <see cref="AirplaneFactory" />. If the instance does not exist, it will be created.
    /// </summary>
    public static AirplaneFactory Instance => _instance ??= new AirplaneFactory();

    /// <summary>
    ///   Creates a new <see cref="Airplane" />.
    /// </summary>
    /// <param name="data">The information required to create the Airplane.</param>
    /// <returns>
    ///   <see cref="Airplane" />
    /// </returns>
    /// <exception cref="NotSupportedException">Thrown if the <see cref="AirplaneType" /> is invalid.</exception>
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