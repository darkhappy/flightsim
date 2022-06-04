using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class TransportFlight : FlyingState
  {
    public TransportFlight(Airplane plane, Task task, double overlap) : base(plane, task)
    {
      Action(overlap);
    }

    protected override void OnArrived(double overlap)
    {
      Plane.State = new DisembarkState((TransportPlane) Plane, (TaskTransport) Task, overlap);
    }

    public override string ToString()
    {
      return "Transporting";
    }
  }
}