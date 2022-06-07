namespace Simulator.Models.Tasks
{
  /// <summary>
  ///   Represents a task where an airplane must rescue a passenger.
  /// </summary>
  public class TaskRescue : Task
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="TaskRescue" /> class.
    /// </summary>
    /// <param name="position">The position of the task.</param>
    public TaskRescue(Position position) : base(position)
    {
    }

    /// <summary>
    ///   Represents the type of the task.
    /// </summary>
    public override TaskType Type => TaskType.Rescue;

    /// <summary>
    ///   Returns a string describing the task.
    /// </summary>
    /// <returns>A string describing the task.</returns>
    public override string ToString()
    {
      return "Officer down at " + Position + "!";
    }
  }
}