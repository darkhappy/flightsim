using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  /// <summary>
  /// Class of Fighting flight state.
  /// </summary>
  public sealed class FightingFlight : FlyingState
  {
    /// <inheritdoc cref="FlyingState(Airplane, Task)" />
    public FightingFlight(Airplane plane, Task task) : base(plane, task)
    {
    }

    /// <inheritdoc cref="FlyingState.OnArrived" />
    protected override void OnArrived(double overlap)
    {
      if (Destination == Task.Position)
      {
        HeadBack(overlap);
      }
      else if (Task.IsCompleted)
      {
        Plane.State = new MaintenanceState(Plane);
        Plane.Action(overlap);
      }
      else
      {
        SetDestination(Task.Position);
        Action(overlap);
      }
    }

    /// <inheritdoc cref="PlaneState.ToString()" />
    public override string ToString()
    {
      return Destination == Task.Position ? $"Handling {Task}"
        : Task.IsCompleted                ? "Returning to base for maintenance"
                                            : "Returning to base to refuel";
    }
  }
}