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

    public override void Action(double time)
    {
      TimeLeft -= time;
      if (TimeLeft <= 0) OnArrived(TimeLeft * -1);
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