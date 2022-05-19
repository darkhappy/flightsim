using System;

namespace Simulator.Models.Tasks
{
  public class TaskFight : Task
  {
    public TaskFight(Position position) : base(position)
    {
    }

    public override void HandleEvent()
    {
      throw new NotImplementedException();
    }
  }
}