using System;

namespace Simulator.Models.States
{
  public class TransportFlight : FlyingState
  {
    public TransportFlight(int speed) : base(speed)
    {
    }

    protected override void OnArrived(double time)
    {
      throw new NotImplementedException();
    }
  }
}