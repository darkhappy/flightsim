using System;
using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  /// <summary>
  ///   Abstract class representing a task where an airplane must transport things from one place to another.
  /// </summary>
  public abstract class TaskTransport : Task
  {
    /// <inheritdoc cref="Amount" />
    private double _amount;

    /// <summary>
    ///   Initializes a new instance of the <see cref="TaskTransport" /> class.
    /// </summary>
    /// <param name="destination">The airport where the airplane must land.</param>
    protected TaskTransport(Airport destination) : base(destination.Position)
    {
      Destination = destination;
    }

    /// <summary>
    ///   Determines whether the airplane is a transport task or not.
    /// </summary>
    public override bool IsTransportTask => true;

    /// <summary>
    ///   Represents the amount of things to transport.
    /// </summary>
    /// <exception cref="ArgumentOutOfRangeException">Thrown when the value is equal to or less than zero.</exception>
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

    /// <summary>
    ///   Represents the airport where the airplane must land.
    /// </summary>
    public Airport Destination { get; }

    /// <summary>
    ///   Merges the current task with another task.
    /// </summary>
    /// <param name="other">The task to merge with.</param>
    /// <returns>True if the tasks can be merged, false otherwise.</returns>
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

    /// <summary>
    ///   Splits the current task into two tasks.
    /// </summary>
    /// <param name="remainder">The amount of things that must be left after the split.</param>
    /// <returns>The new task.</returns>
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