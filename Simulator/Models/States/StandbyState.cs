namespace Simulator.Models.States
{
  /// <summary>
  ///   Represents a state in which the plane is not doing anything.
  /// </summary>
  public class StandbyState : IState
  {
    /// <inheritdoc cref="IState.Action(double)" />
    public void Action(double time)
    {
    }

    /// <inheritdoc cref="TimedState.Current" />
    public Position Current => new Position(-1, -1);

    /// <inheritdoc cref="TimedState.Destination" />
    public Position Destination => new Position(-1, -1);

    /// <inheritdoc cref="IState.ToString" />
    public override string ToString()
    {
      return "Awaiting orders";
    }
  }
}