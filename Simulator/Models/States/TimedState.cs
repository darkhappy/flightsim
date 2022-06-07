using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  public abstract class TimedState : PlaneState
  {
    /// <inheritdoc cref="PlaneState(Airplane)" />
    protected TimedState(Airplane plane) : base(plane)
    {
    }

    /// <inheritdoc cref="PlaneState.Current" />
    /// <remarks>
    ///   Since the plane is not moving, the position is set out of bounds to not render it.
    /// </remarks>
    public override Position Current => new Position(-1, -1);

    /// <inheritdoc cref="PlaneState.Destination" />
    /// <remarks>
    ///   Since the plane is not moving, the position is set out of bounds to not render it.
    /// </remarks>
    public override Position Destination => new Position(-1, -1);

    /// <summary>
    ///   Represents the time left to do the action.
    /// </summary>
    protected double TimeLeft { get; set; }

    /// <summary>
    ///   Decreases the time left to do the action.
    /// </summary>
    /// <param name="time">The time to decrease.</param>
    public override void Action(double time)
    {
      TimeLeft -= time;
      if (TimeLeft <= 0) OnArrived(TimeLeft * -1);
    }
  }
}