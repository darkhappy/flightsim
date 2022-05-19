using System;

namespace Simulator.Models.States
{
  public class ScoutFlight : FlyingState
  {
    public ScoutFlight(int speed) : base(speed)
    {
    }

    protected override void OnArrived(double time)
    {
      throw new NotImplementedException();
    }
  }
}