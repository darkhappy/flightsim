using System;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class FightingFlight : FlyingState
  {
    public FightingFlight(Airplane plane, Task task, double overlap) : base(plane, task)
    {
      Action(overlap);
    }

    protected override void OnArrived(double overlap)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      return "Flying to fight";
    }
  }
}