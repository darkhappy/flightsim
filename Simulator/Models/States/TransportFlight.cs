using System;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public class TransportFlight : FlyingState
  {
    public TransportFlight(int speed, Task task) : base(speed, task)
    {
    }

    protected override void OnArrived(double time)
    {
      throw new NotImplementedException();
    }
  }
}