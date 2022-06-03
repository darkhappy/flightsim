using System;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public class RescueFlight : FlyingState
  {
    public RescueFlight(int speed, Task task) : base(speed, task)
    {
    }

    protected override void OnArrived(double time)
    {
      throw new NotImplementedException();
    }
    public override string ToString()
    {
      return "Rescuing";
    }
  }
}