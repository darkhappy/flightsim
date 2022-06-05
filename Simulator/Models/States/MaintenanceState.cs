using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  public sealed class MaintenanceState : TimedState
  {
    public MaintenanceState(Airplane plane) : base(plane)
    {
      TimeLeft = plane.MaintenanceTime;
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