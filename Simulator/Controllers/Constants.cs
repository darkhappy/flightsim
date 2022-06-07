namespace Simulator.Controllers
{
  /// <summary>
  /// Class that sets all constants that we need in all the project.
  /// </summary>
  public static class Constants
  {
    /// <summary>
    ///   Represents the height of the map.
    /// </summary>
    public const int MapHeight = 630;

    /// <summary>
    ///   Represents the width of the map.
    /// </summary>
    public const int MapWidth = 1125;

    /// <summary>
    ///   Represents the amount of fights in an hour.
    /// </summary>
    public const int MaxFightsPerHour = 3;

    /// <summary>
    ///   Represents the amount of passenger tasks in an hour.
    /// </summary>
    public const int MaxPassengersPerHour = 10;

    /// <summary>
    ///   Represents the amount of cargo tasks in an hour.
    /// </summary>
    public const int MaxCargoPerHour = 10;

    /// <summary>
    ///   Represents the amount of rescues in an hour.
    /// </summary>
    public const int MaxRescuePerHour = 4;

    /// <summary>
    ///   Represents the amount of scouts in an hour.
    /// </summary>
    public const int MaxScoutsPerHour = 2;
  }
}