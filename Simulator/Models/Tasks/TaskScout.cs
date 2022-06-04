namespace Simulator.Models.Tasks
{
  public class TaskScout : Task
  {
    public TaskScout(Position position) : base(position)
    {
    }

    public override string ToString()
    {
      return "Scout at position : " + Position.ToString();
    }
  }
}