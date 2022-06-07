using System;
using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  /// <summary>
  ///   Represents a task where a passenger plane must transport passengers to a destination airport.
  /// </summary>
  public class ClientPassenger : TaskTransport
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="ClientPassenger" /> class with a random amount of passengers.
    /// </summary>
    /// <param name="airport">The airport where the task is to be carried out.</param>
    public ClientPassenger(Airport airport) : base(airport)
    {
      Amount = Math.Round(new Random().NextDouble() * airport.PassengerTraffic + 1) * 5;
    }

    /// <summary>
    ///   Represents the type of the task.
    /// </summary>
    public override TaskType Type => TaskType.Passenger;

    /// <summary>
    ///   Returns a string representation of the task.
    /// </summary>
    /// <returns>The string representation of the task.</returns>
    public override string ToString()
    {
      return Amount + " passengers heading to " + Destination.Name;
    }
  }
}