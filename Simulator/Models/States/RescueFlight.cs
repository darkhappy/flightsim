using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  /// <summary>
  ///   Represents a state in which the plane is rescuing a passenger.
  /// </summary>
  public sealed class RescueFlight : FlyingState
  {
    /// <inheritdoc cref="FlyingState(Airplane, Task)" />
    public RescueFlight(Airplane plane, Task task) : base(plane, task)
    {
    }

    /// <inheritdoc cref="FlyingState.OnArrived" />
    protected override void OnArrived(double overlap)
    {
      if (Destination == Plane.OriginPosition)
      {
        Plane.State = new MaintenanceState(Plane);
        Plane.Action(overlap);
      }
      else
      {
        HeadBack(overlap);
      }
    }

    /// <inheritdoc cref="PlaneState.ToString" />
    public override string ToString()
    {
      return Destination == Plane.OriginPosition ? "Returning to base" : $"Rescuing {Task}";
    }
  }
}