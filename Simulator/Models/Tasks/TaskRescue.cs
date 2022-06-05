namespace Simulator.Models.Tasks
{
  public class TaskRescue : Task
  {
    public TaskRescue(Position position) : base(position)
    {
    }

    public override TaskType Type => TaskType.Rescue;

    public override string ToString()
    {
      return "There is a rescue at position " + Position.ToString();
    }
  }
}