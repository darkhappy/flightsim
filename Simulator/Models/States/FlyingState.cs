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
      Current = Plane.OriginPosition;
    }

    public Position Current { get; set; }

    public Position Destination { get; set; }

    public override void Action(double time)
    {
      var (position, overlap) = CalculateDistance(time);
      Current = position;

      if (Current.Equals(Destination)) OnArrived(overlap);
    }

    public Task Task { get; }

    protected void HeadBack(double overlap)
    {
      Task.HandleEvent();
      Destination = Plane.OriginPosition;
      Action(overlap);
    }

    public virtual Tuple<Position, double> CalculateDistance(double time)
    {
      var distanceX = Destination.X - Current.X;
      var distanceY = Destination.Y - Current.Y;

      var norm = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
      var directionX = distanceX / norm;
      var directionY = distanceY / norm;

      var newX = directionX * Plane.Speed * time;
      var newY = directionY * Plane.Speed * time;

      var newPos = new Position(Convert.ToInt32(newX), Convert.ToInt32(newY));

      // Check if the new position is further than the destination
      var distanceToNewX = newPos.X - Current.X;
      var distanceToNewY = newPos.Y - Current.Y;
      var distanceToNew = Math.Sqrt(Math.Pow(distanceToNewX, 2) + Math.Pow(distanceToNewY, 2));

      if (distanceToNew < norm) return new Tuple<Position, double>(newPos, 0);

      var timeToDo = norm / Plane.Speed;
      var overlap = time - timeToDo;
      newPos = Destination;

      return new Tuple<Position, double>(newPos, overlap);
    }

    public abstract override string ToString();
  }
}