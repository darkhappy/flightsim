using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class TransportFlight : FlyingState
  {
    private readonly TaskTransport _task;

    public TransportFlight(TransportPlane plane, TaskTransport task) : base(plane, task)
    {
      _task = task;
    }

    public override Task Task => _task;

    protected override void OnArrived(double overlap)
    {
      Plane.State = new DisembarkState((TransportPlane) Plane, _task);
      Plane.Action(overlap);
      Plane.TransferTo(_task.Destination);
    }

    public override string ToString()
    {
      return "Transporting";
    }
  }
}