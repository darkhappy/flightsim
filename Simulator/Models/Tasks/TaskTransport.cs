using System;
using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public abstract class TaskTransport : Task
  {
    private double _amount;

    protected TaskTransport(Airport destination) : base(destination.Position)
    {
      Destination = destination;
    }

    public override bool IsTransportTask => true;

    public double Amount
    {
      get => _amount;
      set
      {
        if (value <= 0)
          throw new ArgumentOutOfRangeException(nameof(value), @"Amount must be greater than 0");

        value = Math.Round(value, 2, MidpointRounding.AwayFromZero);
        _amount = value;
      }
    }

    public Airport Destination { get; }

    public bool Merge(TaskTransport other)
    {
      // Check if both tasks are the same type
      if (Type != other.Type) return false;

      // Check if both tasks have the same destination
      if (Destination != other.Destination) return false;

      // Add the amount of both tasks
      Amount += other.Amount;

      // Remove the second task
      Scenario.Instance.RemoveTask(other);
      return true;
    }

    public TaskTransport Split(double remainder)
    {
      // Create a new task with the remainder
      var task = (TaskTransport) Activator.CreateInstance(GetType(), Destination);

      task.Amount = Amount - remainder;
      Amount = remainder;

      Scenario.Instance.AddTask(task);
      return task;
    }
  }
}