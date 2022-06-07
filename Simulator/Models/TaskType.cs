namespace Simulator.Models
{
  /// <summary>
  ///   Represents a type of event that can occur in the simulation.
  ///   This is also used for planes.
  /// </summary>
  public enum TaskType
  {
    Fight,
    Rescue,
    Scout,
    Passenger,
    Cargo
  }
}