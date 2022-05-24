namespace Simulator.Models.States
{
  public abstract class TimedState : IState
  {
    private double _duration;

    protected TimedState(double duration)
    {
      _duration = duration;
    }

    public void Action(double time)
    {
      _duration -= time;
    }
  }
}