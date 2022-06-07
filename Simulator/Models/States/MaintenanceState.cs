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

    /// <inheritdoc cref="PlaneState.OnArrived" />
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
      return "Currently in maintenance for " + TimeLeft + " seconds.";
    }
  }
}