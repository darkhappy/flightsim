using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class DisembarkState : TimedStateWithTask
  {
    public DisembarkState(TransportPlane plane, TaskTransport task) : base(plane, task)
    {
      TimeLeft = plane.DisembarkingTime * task.Amount;
    }

    protected override void OnArrived(double overlap)
    {
      Plane.State = new MaintenanceState(Plane);
      Plane.Action(overlap);
    }

    public override string ToString()
    {
      return "Disembarking";
    }
  }
}