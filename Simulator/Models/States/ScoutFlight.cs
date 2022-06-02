using System;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public class ScoutFlight : FlyingState
  {
    private bool _circling;

    public ScoutFlight(int speed, Task task) : base(speed, task)
    {
      _circling = false;
    }

    private Position calculateInCircle(int radius, Position center)
    {
      var deltaTheta = Speed / radius;
      var thetaI = Math.Acos((double) Current.X / radius);

      if (Current.Y != 0) thetaI *= Math.Sign(Current.Y);

      var thetaN = deltaTheta + thetaI;
      var newX = Convert.ToInt32(Math.Cos(thetaN));
      var newY = Convert.ToInt32(Math.Sin(thetaN));

      return new Position(newX, newY);
    }

    protected override void OnArrived(double time)
    {
      throw new NotImplementedException();
    }
  }
}