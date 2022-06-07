using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class TransportFlight : FlyingState
  {
    private readonly TransportPlane _plane;


    private readonly TaskTransport _task;

    /// <inheritdoc cref="FlyingState(Airplane, Task)" />
    public TransportFlight(TransportPlane plane, TaskTransport task) : base(plane, task)
    {
      _plane = plane;
      _task = task;
    }

    /// <summary>
    ///   Represents the task of the state.
    /// </summary>
    protected override Task Task => _task;

    protected override void OnArrived(double overlap)
    {
      _plane.State = new DisembarkState(_plane, _task);
      _plane.Action(overlap);
      _plane.TransferTo(_task.Destination);
    }

    /// <inheritdoc cref="PlaneState.ToString()" />
    public override string ToString()
    {
      return $"Transporting {_task}";
    }
  }
}