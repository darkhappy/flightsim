using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public class TaskFactory
  {
    private static TaskFactory _instance;

    public static TaskFactory Instance => _instance ??= new TaskFactory();

    public TaskFight CreateFightTask()
    {
      return new TaskFight(Position.GetRandomPosition());
    }

    public TaskRescue CreateRescueTask()
    {
      return new TaskRescue(Position.GetRandomPosition());
    }

    public TaskScout CreateScoutTask()
    {
      return new TaskScout(Position.GetRandomPosition());
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