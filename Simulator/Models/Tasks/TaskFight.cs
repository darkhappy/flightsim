using System;

namespace Simulator.Models.Tasks
{
  public class TaskFight : Task
  {
    public TaskFight(Position position) : base(position)
    {
      Health = new Random().Next(1, 6);
    }

    public int Health { get; private set; }

    public override TaskType Type => TaskType.Fight;

    public override void HandleEvent()
    {
      Health--;
      if (Health <= 0) base.HandleEvent();
    }
    public override string ToString()
    {
      return "Rebels began a fight at " + Position.ToString();
    }
  }
}