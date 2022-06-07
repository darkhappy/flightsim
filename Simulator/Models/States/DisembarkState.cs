using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  /// <summary>
  /// Class sealed of a disembark state.
  /// </summary>
  public sealed class DisembarkState : TimedStateWithTask
  {
    /// <summary>
    /// Constructor of a disembark state.
    /// </summary>
    /// <param name="plane"></param>
    /// <param name="task"></param>
    public DisembarkState(TransportPlane plane, TaskTransport task) : base(plane, task)
    {
      TimeLeft = plane.DisembarkingTime * task.Amount;
    }

    /// <summary>
    /// Override OnArrived and calls action.
    /// </summary>
    /// <param name="overlap"></param>
    protected override void OnArrived(double overlap)
    {
      Plane.State = new MaintenanceState(Plane);
      Plane.Action(overlap);
    }

    /// <inheritdoc cref="PlaneState.ToString()" />
    public override string ToString()
    {
      return $"Disembarking {Task} ({TimeLeft} seconds)";
    }
  }
}