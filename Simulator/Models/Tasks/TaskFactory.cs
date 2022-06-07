using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  /// <summary>
  ///   Factory for creating tasks.
  /// </summary>
  public class TaskFactory
  {
    /// <summary>
    ///   Represents the task factory.
    /// </summary>
    private static TaskFactory? _instance;

    /// <summary>
    ///   Returns the task factory. If it does not exist, it is created.
    /// </summary>
    public static TaskFactory Instance => _instance ??= new TaskFactory();

    /// <summary>
    ///   Creates a new fighting task.
    /// </summary>
    /// <returns>The new fighting task.</returns>
    public TaskFight CreateFightTask()
    {
      return new TaskFight(Position.GetRandomPosition());
    }

    /// <summary>
    ///   Creates a new rescue task.
    /// </summary>
    /// <returns>The new rescue task.</returns>
    public TaskRescue CreateRescueTask()
    {
      return new TaskRescue(Position.GetRandomPosition());
    }

    /// <summary>
    ///   Creates a new scouting task.
    /// </summary>
    /// <returns>The new scouting task.</returns>
    public TaskScout CreateScoutTask()
    {
      return new TaskScout(Position.GetRandomPosition());
    }

    /// <summary>
    ///   Creates a new passenger task.
    /// </summary>
    /// <param name="airport">The airport to which the passengers are heading to.</param>
    /// <returns>The new passenger task.</returns>
    public ClientPassenger CreatePassengerTask(Airport airport)
    {
      return new ClientPassenger(airport);
    }

    /// <summary>
    ///   Creates a new cargo task.
    /// </summary>
    /// <param name="airport">The airport to which the cargo is heading to.</param>
    /// <returns>The new cargo task.</returns>
    public ClientCargo CreateCargoTask(Airport airport)
    {
      return new ClientCargo(airport);
    }
  }
}