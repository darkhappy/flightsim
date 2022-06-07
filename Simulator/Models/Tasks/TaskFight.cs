using System;

namespace Simulator.Models.Tasks
{
  /// <summary>
  ///   Represents a task where an airplane must combat rebels at a given location.
  /// </summary>
  public class TaskFight : Task
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="TaskFight" /> class.
    /// </summary>
    /// <param name="position">The position of the task.</param>
    public TaskFight(Position position) : base(position)
    {
      Health = new Random().Next(1, 6);
    }

    /// <summary>
    ///   Represents the amount of health that the fight task has.
    /// </summary>
    public int Health { get; private set; }

    /// <summary>
    ///   Represents the type of the task.
    /// </summary>
    public override TaskType Type => TaskType.Fight;

    /// <summary>
    ///   Removes health from the task. If the task is defeated, it is removed from the task list.
    /// </summary>
    public override void HandleEvent()
    {
      Health--;
      if (Health <= 0) base.HandleEvent();
    }

    /// <summary>
    ///   Returns a string representation of the task.
    /// </summary>
    /// <returns>The string representation of the task.</returns>
    public override string ToString()
    {
      return "Rebels spotted at " + Position + "!";
    }
  }
}