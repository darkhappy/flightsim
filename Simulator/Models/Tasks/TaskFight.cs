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

    public override void HandleEvent()
    {
      Health--;
      if (Health <= 0) base.HandleEvent();
    }
  }
}