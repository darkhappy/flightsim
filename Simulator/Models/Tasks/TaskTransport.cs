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

    public double Amount { get; set; }

    public Airport Destination { get; }

    public TaskTransport Merge(TaskTransport task1, TaskTransport task2)
    {
      // Check if both tasks are the same type
      if (task1.GetType() != task2.GetType()) throw new ArgumentException("Tasks are not the same type");

      // Check if both tasks have the same destination
      if (task1.Destination != task2.Destination) throw new ArgumentException("Tasks have different destinations");

      // Add the amount of both tasks
      task1.Amount += task2.Amount;

      // Remove the second task
      Scenario.Instance.RemoveTask(task2);

      return task1;
    }
  }
}