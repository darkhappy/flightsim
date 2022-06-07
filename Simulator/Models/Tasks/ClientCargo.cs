using System;
using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public class ClientCargo : TaskTransport
  {
    public ClientCargo(Airport airport) : base(airport)
    {
      Amount = (new Random().NextDouble() * airport.CargoTraffic + 1) * 5;
    }

    /// <summary>
    ///   Represents the type of the task.
    /// </summary>
    public override TaskType Type => TaskType.Cargo;

    /// <summary>
    ///   Returns a string representation of the task.
    /// </summary>
    /// <returns>The string representation of the task.</returns>
    public override string ToString()
    {
      return Amount + " tons of cargo heading to " + Destination.Name;
    }
  }
}