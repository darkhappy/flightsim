using System;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class ScoutFlight : FlyingState
  {
    private bool _circling;

    public ScoutFlight(Airplane plane, Task task) : base(plane, task)
    {
      _circling = false;
    }

    private Position calculateInCircle(int radius, Position center)
    {
      var deltaTheta = Plane.Speed / radius;
      var thetaI = Math.Acos((double) Current.X / radius);

      if (Current.Y != 0) thetaI *= Math.Sign(Current.Y);

      var thetaN = deltaTheta + thetaI;
      var newX = Convert.ToInt32(Math.Cos(thetaN));
      var newY = Convert.ToInt32(Math.Sin(thetaN));

      return new Position(newX, newY);
    }

    protected override void OnArrived(double overlap)
    {
      if (Destination == Task.Position)
        HeadBack(overlap);
      else
      {
        Plane.State = new MaintenanceState(Plane);
        Plane.Action(overlap);
      }
    }

    public override string ToString()
    {
      return "Scouting";
    }
  }
}