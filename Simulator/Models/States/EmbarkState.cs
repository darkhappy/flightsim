using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  /// <summary>
  /// Class of an embark state.
  /// </summary>
  public sealed class EmbarkState : TimedStateWithTask
  {
    /// <summary>
    /// Member data airplane.
    /// </summary>
    private readonly TransportPlane _plane;

    /// <summary>
    ///   Task of the state.
    /// </summary>
    private readonly TaskTransport _task;

    /// <summary>
    /// Constructor of state.
    /// </summary>
    /// <param name="plane"></param>
    /// <param name="task"></param>
    public EmbarkState(TransportPlane plane, TaskTransport task) : base(plane, task)
    {
      _plane = plane;
      _task = task;
      TimeLeft = plane.EmbarkingTime * task.Amount;
    }

    /// <summary>
    /// Method that is called upon arrival of the task. 
    /// </summary>
    /// <param name="overlap">The amount of time that the airplane overlaps with the next task.</param>
    protected override void OnArrived(double overlap)
    {
      _plane.State = new TransportFlight(_plane, _task);
      _plane.Action(overlap);
    }

    /// <inheritdoc cref="PlaneState.ToString()" />
    public override string ToString()
    {
      return $"Embarking {Task} ({TimeLeft} seconds)";
    }
  }
}