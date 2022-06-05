using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public sealed class RescueFlight : FlyingState
  {
    public RescueFlight(Airplane plane, Task task, double overlap) : base(plane, task)
    {
      Action(overlap);
    }

    protected override void OnArrived(double overlap)
    {
      if (Destination == Plane.OriginPosition)
      {
        Plane.State = new MaintenanceState(Plane, overlap);
      }
      else
      {
        HeadBack(overlap);
      }
    }

    public override string ToString()
    {
      return Destination == Plane.OriginPosition ? "Returning to base" : Task.ToString();
    }
  }
}