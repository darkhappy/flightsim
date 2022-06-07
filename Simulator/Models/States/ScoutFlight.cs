using System;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  /// <summary>
  ///   Represents a state in which the airplane is scouting around a target.
  /// </summary>
  public sealed class ScoutFlight : FlyingState
  {
    /// <summary>
    ///   Represents the radius of the circle in which the airplane will fly around the target.
    /// </summary>
    private const int Radius = 50;

    /// <summary>
    ///   Represents whether the plane is circling or not.
    /// </summary>
    private bool _circling;

    /// <inheritdoc cref="FlyingState(Airplane, Task)" />
    public ScoutFlight(Airplane plane, Task task) : base(plane, task)
    {
      _circling = false;
    }

    /// <summary>
    ///   Represents a position for the circle.
    /// </summary>
    private Position CirclingPosition => new Position(Destination.X - Radius, Destination.Y - Radius);

    /// <inheritdoc cref="PlaneState.Action" />
    public override void Action(double time)
    {
      if (time == 0) return;

      Tuple<Position, double> poslapbitch;

      poslapbitch = _circling ? CalculateInCircle(Radius, time) : CalculateDistance(time);

      var position = poslapbitch.Item1;
      var overlap = poslapbitch.Item2;

      SetPosition(position);

      if (Current.Equals(Destination))
        OnArrived(overlap);
    }

    /// <summary>
    ///   Calculates a position based on a circle.
    /// </summary>
    /// <param name="radius">The radius of the circle.</param>
    /// <param name="time">The time to calculate the position for.</param>
    /// <returns>A tuple containing the position and the overlap.</returns>
    private Tuple<Position, double> CalculateInCircle(int radius, double time)
    {
      var deltaTheta = Plane.Speed * time / radius;
      var thetaI = Math.Acos((double) Current.X / radius);

      if (Current.Y != 0) thetaI *= Math.Sign(Current.Y);

      var thetaN = deltaTheta + thetaI;
      var newX = Convert.ToInt32(Math.Cos(thetaN));
      var newY = Convert.ToInt32(Math.Sin(thetaN));

      return new Tuple<Position, double>(new Position(newX, newY), time);
    }

    /// <inheritdoc cref="FlyingState.CalculateDistance" />
    public override Tuple<Position, double> CalculateDistance(double time)
    {
      var distanceX = CirclingPosition.X - Current.X;
      var distanceY = CirclingPosition.Y - Current.Y;

      var norm = Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));

      // If the plane is already at the destination (such as if the task is at the same position)
      // This is an edge case to prevent a divide by zero error
      if (norm == 0)
        return new Tuple<Position, double>(CirclingPosition, time);

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
      newPos = CirclingPosition;

      return new Tuple<Position, double>(newPos, overlap);
    }

    /// <inheritdoc cref="PlaneState.OnArrived" />
    protected override void OnArrived(double overlap)
    {
      if (Destination == Task.Position)
      {
        if (!_circling)
        {
          _circling = true;
          Action(overlap);
        }
        else
        {
          HeadBack(overlap);
        }
      }
      else
      {
        Plane.State = new MaintenanceState(Plane);
        Plane.Action(overlap);
      }
    }

    /// <inheritdoc cref="PlaneState.ToString()" />
    public override string ToString()
    {
      return $"Scouting {Task}";
    }
  }
}