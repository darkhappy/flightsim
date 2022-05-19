using System;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public abstract class FlyingState : ITaskState
  {
    private Position _current;
    private Position _destination;
    private int _speed;

    protected FlyingState(int speed)
    {
      _speed = speed;
    }

    public void Action(double time)
    {
      var result = CalculateDistance();
      _current = result.Item1;

      if (_current.Equals(_destination)) OnArrived(result.Item2);
    }

    public Task Task { get; }

    private Tuple<Position, double> CalculateDistance()
    {
      throw new NotImplementedException();
    }

    protected abstract void OnArrived(double time);
  }
}