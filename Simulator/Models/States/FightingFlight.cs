using System;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public class FightingFlight : FlyingState
  {
    public FightingFlight(int speed, Task task) : base(speed, task)
    {
    }

    protected override void OnArrived(double time)
    {
      throw new NotImplementedException();
    }
    public override string ToString()
    {
      return "Flying to fight";
    }
  }
}