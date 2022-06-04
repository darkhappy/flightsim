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

    public void Merge(TaskTransport other)
    {
      // Check if both tasks are the same type
      if (GetType() != other.GetType()) return;

      // Check if both tasks have the same destination
      if (Destination != other.Destination) return;

      // Add the amount of both tasks
      Amount += other.Amount;

      // Remove the second task
      Scenario.Instance.RemoveTask(other);
    }
  }
}