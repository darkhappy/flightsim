using System;

namespace Simulator.Models.Tasks
{
  public class TaskFactory
  {
    private static TaskFactory _instance;

    public static TaskFactory Instance => _instance ?? (_instance = new TaskFactory());

    private Position GetRandomPosition()
    {
      throw new NotImplementedException();
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

    public ClientPassenger CreatePassengerTask()
    {
      return new ClientPassenger(GetRandomPosition());
    }

    public ClientMerchandise CreateMerchandiseTask()
    {
      return new ClientMerchandise(GetRandomPosition());
    }
  }
}