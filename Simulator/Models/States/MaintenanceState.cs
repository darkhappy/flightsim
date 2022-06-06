using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  /// <summary>
  /// Class of maintenance state.
  /// </summary>
  public sealed class MaintenanceState : TimedState
  {
    /// <summary>
    /// Constructor of maintenance state.
    /// </summary>
    /// <param name="plane"></param>
    public MaintenanceState(Airplane plane) : base(plane)
    {
      TimeLeft = plane.MaintenanceTime;
    }

    /// <summary>
    /// Onarrived.
    /// </summary>
    /// <param name="overlap"></param>
    protected override void OnArrived(double overlap)
    {
      Plane.State = new StandbyState();
    }

    /// <summary>
    /// ToString override of maintenance state.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "In Maintenace";
    }
  }
}