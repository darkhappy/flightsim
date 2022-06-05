using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class EmbarkState : TimedStateWithTask
  {
    private new TransportPlane Plane;

    public EmbarkState(TransportPlane plane, TaskTransport task, double overlap) : base(plane, task)
    {
      TimeLeft = plane.EmbarkingTime * task.Amount;
      Action(overlap);
    }

    protected override void OnArrived(double overlap)
    {
      Plane.State = new TransportFlight(Plane, (TaskTransport) Task, overlap);
    }

    public override string ToString()
    {
      return "Embarking";
    }
  }
}