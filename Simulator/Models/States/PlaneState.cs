using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  /// <summary>
  ///   Represents the state of an airplane when it is in the air.
  /// </summary>
  public abstract class PlaneState : IState
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="PlaneState" /> class.
    /// </summary>
    /// <param name="plane">The plane.</param>
    protected PlaneState(Airplane plane)
    {
      Plane = plane;
    }

    /// <summary>
    ///   Represents the plane.
    /// </summary>
    protected Airplane Plane { get; }

    /// <inheritdoc cref="IState.Action" />
    public abstract void Action(double time);

    /// <inheritdoc cref="IState.Current" />
    public abstract Position Current { get; }

    /// <inheritdoc cref="IState.Destination" />
    public abstract Position Destination { get; }

    /// <summary>
    ///   Represents a string representation of what the plane is doing.
    /// </summary>
    /// <returns>The string representation.</returns>
    public new abstract string ToString();

    /// <summary>
    ///   Represents the action to do when finishing it's action. For example, when a plane arrives at it's destination.
    /// </summary>
    /// <param name="overlap"></param>
    protected abstract void OnArrived(double overlap);
  }
}