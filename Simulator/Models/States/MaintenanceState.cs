using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  public class MaintenanceState : IState
  {
    private readonly Airplane _plane;
    private double _timeLeft;

    public MaintenanceState(Airplane plane, double overlap)
    {
      _plane = plane;
      _timeLeft = plane.MaintenanceTime;
      Action(overlap);
    }

    public void Action(double time)
    {
      _timeLeft -= time;
      if (_timeLeft <= 0) _plane.State = new StandbyState();
    }

    public override string ToString()
    {
      return "In Maintenace";
    }
  }
}