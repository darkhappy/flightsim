using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class EmbarkState : TimedStateWithTask
  {
    private new TransportPlane Plane;

    public EmbarkState(TransportPlane plane, TaskTransport task) : base(plane, task)
    {
      Plane = plane;
      TimeLeft = plane.EmbarkingTime * task.Amount;
    }

    protected override void OnArrived(double overlap)
    {
      Plane.State = new TransportFlight(Plane, (TaskTransport) Task);
      Plane.Action(overlap);
    }

    public override string ToString()
    {
      return "Embarking";
    }
  }
}