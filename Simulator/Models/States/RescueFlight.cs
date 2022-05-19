using System;

namespace Simulator.Models.States
{
  public class RescueFlight : FlyingState
  {
    public RescueFlight(int speed) : base(speed)
    {
    }

    protected override void OnArrived(double time)
    {
      throw new NotImplementedException();
    }
  }
}