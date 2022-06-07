namespace Simulator.Models.Tasks
{
  /// <summary>
  ///   Represents a task where a plane must circle around a specified point.
  /// </summary>
  public class TaskScout : Task
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="TaskScout" /> class.
    /// </summary>
    /// <param name="position">The position to scout.</param>
    public TaskScout(Position position) : base(position)
    {
    }

    /// <summary>
    ///   Represents the type of task.
    /// </summary>
    public override TaskType Type => TaskType.Scout;

    /// <summary>
    ///   Returns a string describing the task.
    /// </summary>
    /// <returns>A string describing the task.</returns>
    public override string ToString()
    {
      return "Valuable intel at " + Position + ".";
    }
  }
}