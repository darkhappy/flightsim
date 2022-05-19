using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  public abstract class Airplane
  {
    private readonly IState _state;

    protected Airplane(string id, string name, Position position, int speed, int maintenanceTime, Airport origin)
    {
      Id = id;
      Name = name;
      Position = position;
      Speed = speed;
      MaintenanceTime = maintenanceTime;
      Origin = origin;
      _state = new StandbyState();
    }

    public string Id { get; set; }

    public string Name { get; set; }

    public Position Position { get; set; }

    public int Speed { get; set; }

    public int MaintenanceTime { get; set; }

    public Airport Origin { get; set; }

    public abstract Colour Colour { get; }

    public void Action(double time)
    {
      _state.Action(time);
    }

    public abstract void ChangeState();

    public abstract void ChangeState(Task task);

    public abstract void AssignTask(Task task);
  }
}