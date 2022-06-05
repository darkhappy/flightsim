using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class FightingFlight : FlyingState
  {
    public FightingFlight(Airplane plane, Task task) : base(plane, task)
    {
    }

    protected override void OnArrived(double overlap)
    {
      if (Destination == Task.Position)
      {
        HeadBack(overlap);
      }
      else if (Task.IsCompleted)
      {
        Plane.State = new MaintenanceState(Plane);
        Plane.Action(overlap);
      }
      else
      {
        Destination = Task.Position;
        Action(overlap);
      }
    }

    public override string ToString()
    {
      return "Flying to fight";
    }
  }
}