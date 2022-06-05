using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  public abstract class PlaneState : IState
  {
    protected PlaneState(Airplane plane)
    {
      Plane = plane;
    }

    protected Airplane Plane { get; set; }

    public abstract void Action(double time);

    public abstract Position Current { get; }

    protected abstract void OnArrived(double overlap);
  }
}