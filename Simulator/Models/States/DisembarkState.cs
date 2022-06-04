using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class DisembarkState : TimedStateWithTask
  {
    public DisembarkState(TransportPlane plane, TaskTransport task, double overlap) : base(plane, task)
    {
      TimeLeft = plane.DisembarkingTime * task.Amount;
      Action(overlap);
    }

    protected override void OnArrived(double overlap)
    {
      Plane.State = new MaintenanceState(Plane, overlap);
    }

    public override string ToString()
    {
      return "Disembarking";
    }
  }
}