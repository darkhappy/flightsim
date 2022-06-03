using System;
using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public abstract class TaskTransport : Task
  {
    protected TaskTransport(Position position) : base(position)
    {
      Destination = Scenario.Instance.GetFromPosition(position);
    }

    protected TaskTransport(Airport destination) : base(destination.Position)
    {
      Destination = destination;
    }

    public double Amount { get; set; }

    public Airport Destination { get; }

    public TaskTransport Merge(TaskTransport other)
    {
      // Check if both tasks are the same type
      if (GetType() != other.GetType()) throw new ArgumentException("Tasks are not the same type");

      // Check if both tasks have the same destination
      if (Destination != other.Destination) throw new ArgumentException("Tasks have different destinations");

      // Add the amount of both tasks
      Amount += other.Amount;

      // Remove the second task
      Scenario.Instance.RemoveTask(other);

      return this;
    }
  }
}