using System;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public abstract class FlyingState : PlaneState, ITaskState
  {
    protected FlyingState(Airplane plane, Task task)
    {
      Task = task;
      Destination = task.Position;
      Plane = plane;
    }

    public Position Current { get; set; }

    public Position Destination { get; set; }

    public override void Action(double time)
    {
      var (position, timeLeft) = CalculateDistance();
      Current = position;

      if (Current.Equals(Destination)) OnArrived(timeLeft);
    }

    public Task Task { get; }

    protected virtual Tuple<Position, double> CalculateDistance()
    {
      var distanceX = Destination.X - Current.X;
      var distanceY = Destination.Y - Current.Y;

      var norm = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
      var directionX = distanceX / norm;
      var directionY = distanceY / norm;

      var newX = directionX * Plane.Speed;
      var newY = directionY * Plane.Speed;

      var newPos = new Position(Convert.ToInt32(newX), Convert.ToInt32(newY));

      // TODO: Calculate the overlap remaining in case we arrive before the tick is over
      throw new NotImplementedException();
    }

    public abstract override string ToString();
  }
}