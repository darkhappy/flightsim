namespace Simulator.Models.Tasks
{
  /// <summary>
  ///   Abstract class representing a task a <see cref="Airplanes.Airplane" /> can perform.
  /// </summary>
  public abstract class Task
  {
    /// <summary>
    ///   Initializes a new instance of the <see cref="Task" /> class.
    /// </summary>
    /// <param name="position">The position of the task.</param>
    protected Task(Position position)
    {
      Position = position;
      IsCompleted = false;
    }

    /// <summary>
    ///   Represents the position of the task.
    /// </summary>
    public Position Position { get; }

    /// <summary>
    ///   Defines if the task is completed.
    /// </summary>
    public bool IsCompleted { get; private set; }

    /// <summary>
    ///   Represents the type of the task.
    /// </summary>
    public abstract TaskType Type { get; }

    /// <summary>
    ///   Represents if the task is a transportation task.
    /// </summary>
    /// <seealso cref="IsTransportTask" />
    public virtual bool IsTransportTask => false;

    /// <summary>
    ///   Handles the completion of the task by removing it from the <see cref="Scenario.Tasks" /> list.
    /// </summary>
    public virtual void HandleEvent()
    {
      IsCompleted = true;
      Scenario.Instance.RemoveTask(this);
    }
  }
}