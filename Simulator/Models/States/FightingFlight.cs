using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  /// <summary>
  /// Class of Fighting flight state.
  /// </summary>
  public sealed class FightingFlight : FlyingState
  {
    /// <summary>
    /// Constructor.
    /// </summary>
    /// <param name="plane"></param>
    /// <param name="task"></param>
    public FightingFlight(Airplane plane, Task task) : base(plane, task)
    {
    }

    /// <summary>
    /// Onarrived method that calls action.
    /// </summary>
    /// <param name="overlap"></param>
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
        SetDestination(Task.Position);
        Action(overlap);
      }
    }

    /// <summary>
    /// ToString of state.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "Flying to fight";
    }
  }
}