using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  public abstract class TimedState : PlaneState
  {
    protected TimedState(Airplane plane)
    {
      Plane = plane;
    }

    public override Position Current => new Position(-1, -1);

    protected double TimeLeft { get; set; }

    public override void Action(double time)
    {
      TimeLeft -= time;
      if (TimeLeft <= 0) OnArrived(TimeLeft * -1);
    }

    public override string ToString()
    {
      return "Timed";
    }
  }
}