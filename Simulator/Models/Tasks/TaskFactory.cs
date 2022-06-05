using System;
using Simulator.Controllers;
using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public class TaskFactory
  {
    private static TaskFactory? _instance;

    public static TaskFactory Instance => _instance ??= new TaskFactory();

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

    private Position GetRandomPosition()
    {
      var random = new Random();
      var x = random.Next(0, Constants.MapWidth);
      var y = random.Next(0, Constants.MapHeight);
      var position = new Position(x, y);

      return position;
    }
  }
}