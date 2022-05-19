using System;

namespace Simulator.Models.States
{
  public class FightingFlight : FlyingState
  {
    public FightingFlight(int speed) : base(speed)
    {
    }

    protected override void OnArrived(double time)
    {
      throw new NotImplementedException();
    }
  }
}