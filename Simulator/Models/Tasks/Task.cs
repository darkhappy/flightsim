namespace Simulator.Models.Tasks
{
  public abstract class Task
  {
    protected Task(Position position)
    {
      Position = position;
    }

    public Position Position { get; }

    public virtual void HandleEvent()
    {
      Scenario.Instance.RemoveTask(this);
    }
  }
}