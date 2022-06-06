using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  /// <summary>
  /// Class of an embark state.
  /// </summary>
  public sealed class EmbarkState : TimedStateWithTask
  {
    /// <summary>
    /// Member data airplane.
    /// </summary>
    private new TransportPlane Plane;

    /// <summary>
    /// Constructor of state.
    /// </summary>
    /// <param name="plane"></param>
    /// <param name="task"></param>
    public EmbarkState(TransportPlane plane, TaskTransport task) : base(plane, task)
    {
      Plane = plane;
      TimeLeft = plane.EmbarkingTime * task.Amount;
    }

    /// <summary>
    /// Override OnArrived and calls Action.
    /// </summary>
    /// <param name="overlap"></param>
    protected override void OnArrived(double overlap)
    {
      Plane.State = new TransportFlight(Plane, (TaskTransport) Task);
      Plane.Action(overlap);
    }

    /// <summary>
    /// ToString of state.
    /// </summary>
    /// <returns></returns>
    public override string ToString()
    {
      return "Embarking";
    }
  }
}