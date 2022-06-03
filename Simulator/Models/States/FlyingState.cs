using System;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public abstract class FlyingState : ITaskState
  {
    protected readonly int Speed;
    protected Position Current;
    protected Position Destination;

    protected FlyingState(int speed, Task task)
    {
      Speed = speed;
      Task = task;
    }

    public void Action(double time)
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

      var newX = directionX * Speed;
      var newY = directionY * Speed;

      var newPos = new Position(Convert.ToInt32(newX), Convert.ToInt32(newY));

      // TODO: Calculate the time remaining in case we arrive before the tick is over
      throw new NotImplementedException();
    }

    protected abstract void OnArrived(double time);
    public override string ToString()
    {
      return "Flying";
    }
  }
}