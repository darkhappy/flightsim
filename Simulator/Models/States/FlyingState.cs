using System;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  /// <summary>
  /// Class of flying state.
  /// </summary>
  public abstract class FlyingState : PlaneState
  {
    /// <summary>
    /// Member data of current position as Position.
    /// </summary>
    private Position _current;

    /// <summary>
    /// Member data of destination position as Position. 
    /// </summary>
    private Position _destination;

    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="plane">The plane.</param>
    /// <param name="task">The task to handle.</param>
    protected FlyingState(Airplane plane, Task task) : base(plane)
    {
      Task = task;
      _destination = task.Position;
      _current = plane.OriginPosition;
    }

    /// <summary>
    ///   Defines where the plane is going to.
    /// </summary>
    public override Position Destination => _destination;

    /// <summary>
    ///   Defines where the plane is currently.
    /// </summary>
    public override Position Current => _current;

    /// <summary>
    /// Represents the task that the plane is handling. 
    /// </summary>
    protected virtual Task Task { get; }

    /// <summary>
    ///   Moves the plane to the next position. If the plane is at the destination, the plane will call
    ///   <see cref="PlaneState.OnArrived" /> method.
    /// </summary>
    /// <param name="time">The amount of time to move.</param>
    public override void Action(double time)
    {
      if (time == 0) return;

      var (position, overlap) = CalculateDistance(time);
      _current = position;

      if (Current.Equals(Destination))
        OnArrived(overlap);
    }

    /// <summary>
    ///   Sets the destination of the plane.
    /// </summary>
    /// <remarks>
    ///   The only reason we do not use a setter in the property is due to the property coming from the base class. We
    ///   need to ensure that the destination is only set by the state, and there is no way to do this with an interface.
    /// </remarks>
    /// <param name="destination">The position to which the plane should fly to.</param>
    protected void SetDestination(Position destination)
    {
      _destination = destination;
    }

    /// <summary>
    /// Sets the position.
    /// </summary>
    /// <remarks>
    ///   The only reason we do not use a setter in the property is due to the property coming from the base class. We
    ///   need to ensure that the destination is only set by the state, and there is no way to do this with an interface.
    /// </remarks>
    /// <param name="current">The position to which the plane should go to.</param>
    protected void SetPosition(Position current)
    {
      _current = current;
    }

    /// <summary>
    /// Heads back to the origin. 
    /// </summary>
    /// <param name="overlap">The amount of time to progress in the next state.</param>
    protected void HeadBack(double overlap)
    {
      Task.HandleEvent();
      _destination = Plane.OriginPosition;
      Action(overlap);
    }

    /// <summary>
    /// Method that calculates the distance between the flying plane and destination.
    /// </summary>
    /// <param name="time">The amount of time the plane will be flying.</param>
    /// <returns>A tuple of the position and the amount of time the plane will be flying.</returns>
    public virtual Tuple<Position, double> CalculateDistance(double time)
    {
      var distanceX = Destination.X - Current.X;
      var distanceY = Destination.Y - Current.Y;

      var norm = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));

      // If the plane is already at the destination (such as if the task is at the same position)
      // This is an edge case to prevent a divide by zero error
      if (norm == 0)
        return new Tuple<Position, double>(Destination, time);

      var directionX = distanceX / norm;
      var directionY = distanceY / norm;

      double newX;
      double newY;

      newX = Current.X + directionX * Plane.Speed * time;
      newY = Current.Y + directionY * Plane.Speed * time;

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
  }
}