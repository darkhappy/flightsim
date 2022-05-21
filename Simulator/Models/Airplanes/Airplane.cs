using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  public abstract class Airplane
  {
    protected Airplane(string id, string name, int speed, int maintenanceTime, Airport origin)
    {
      Id = id;
      Name = name;
      Speed = speed;
      MaintenanceTime = maintenanceTime;
      Origin = origin;
      State = new StandbyState();
    }

    public IState State { get; }

    public string Id { get; set; }

    public string Name { get; set; }

    public int Speed { get; set; }

    public int MaintenanceTime { get; set; }

    public Airport Origin { get; set; }

    public abstract Colour Colour { get; }

    public void Action(double time)
    {
      State.Action(time);
    }

    public abstract void ChangeState();

    public abstract void ChangeState(Task task);

    public abstract bool AssignTask(Task task);
  }
}