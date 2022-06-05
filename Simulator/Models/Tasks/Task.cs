namespace Simulator.Models.Tasks
{
  public abstract class Task
  {
    protected Task(Position position)
    {
      Position = position;
      IsCompleted = false;
    }

    public Position Position { get; }
    public bool IsCompleted { get; private set; }

    public virtual void HandleEvent()
    {
      IsCompleted = true;
      Scenario.Instance.RemoveTask(this);
    }
  }
}