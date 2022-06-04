using System;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class EmbarkState : TimedStateWithTask
  {
    public EmbarkState(TransportPlane plane, Task task, double overlap) : base(plane, task)
    {
      TimeLeft = plane.EmbarkingTime;
      Action(overlap);
    }

    public override void Action(double time)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      return "Embarking";
    }
  }
}