using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  public abstract class PlaneState : IState
  {
    protected PlaneState(Airplane plane)
    {
      Plane = plane;
      Destination = new Position(-1, -1);
    }

    protected Airplane Plane { get; set; }

    public abstract void Action(double time);

    public abstract Position Current { get; }

    public virtual Position Destination { get; set; }


    protected abstract void OnArrived(double overlap);
  }
}