using System;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class DisembarkState : TimedStateWithTask
  {
    public DisembarkState(TransportPlane plane, Task task, double overlap) : base(plane, task)
    {
      TimeLeft = plane.DisembarkingTime;
      Action(overlap);
    }

    public override void Action(double time)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      return "Disembarking";
    }
  }
}