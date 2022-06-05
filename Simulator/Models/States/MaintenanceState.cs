using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  public sealed class MaintenanceState : TimedState
  {
    public MaintenanceState(Airplane plane, double overlap) : base(plane)
    {
      TimeLeft = plane.MaintenanceTime;
      Action(overlap);
    }

    protected override void OnArrived(double overlap)
    {
      Plane.State = new StandbyState();
    }

    public override string ToString()
    {
      return "In Maintenace";
    }
  }
}