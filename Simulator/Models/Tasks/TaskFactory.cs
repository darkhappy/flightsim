using System;
using System.Linq;
using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public class TaskFactory
  {
    private static TaskFactory _instance;

    public static TaskFactory Instance => _instance ??= new TaskFactory();

    private static Position GetRandomPosition()
    {
      var random = new Random();
      var x = random.Next(0, Controllers.Simulator.MapWidth);
      var y = random.Next(0, Controllers.Simulator.MapHeight);
      var position = new Position(x, y);

      // Verify if there is a task in the position
      while (Scenario.Instance.Tasks.Any(task => task.Position.Equals(position))) return GetRandomPosition();

      return position;
    }

    public TaskFight CreateFightTask()
    {
      return new TaskFight(GetRandomPosition());
    }

    public TaskRescue CreateRescueTask()
    {
      return new TaskRescue(GetRandomPosition());
    }

    public TaskScout CreateScoutTask()
    {
      return new TaskScout(GetRandomPosition());
    }

    public ClientPassenger CreatePassengerTask(Airport airport)
    {
      return new ClientPassenger(airport);
    }

    public ClientCargo CreateCargoTask(Airport airport)
    {
      return new ClientCargo(airport);
    }
  }
}