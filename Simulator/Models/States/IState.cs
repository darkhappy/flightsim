namespace Simulator.Models.States
{
  /// <summary>
  /// Represents a state in which the airplane can be in.
  /// </summary>
  public interface IState
  {
    /// <summary>
    ///   The current position of the airplane.
    /// </summary>
    Position Current { get; }

    /// <summary>
    ///   The current destination of the airplane.
    /// </summary>
    Position Destination { get; }

    /// <summary>
    ///   Perform the action of the state.
    /// </summary>
    /// <param name="time">The amount of time to perform the action.</param>
    void Action(double time);

    /// <summary>
    ///   Returns a string representation of the state.
    /// </summary>
    /// <returns>The string representation of the state.</returns>
    string ToString();
  }
}