using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  public abstract class TimedState : IPlaneState
  {
    protected TimedState(Airplane plane)
    {
      Plane = plane;
    }

    protected double TimeLeft { get; set; }
    public Airplane Plane { get; }

    public abstract void Action(double time);

    public override string ToString()
    {
      return "Timed";
    }
  }
}