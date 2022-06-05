namespace Simulator.Models.States
{
  public interface IState
  {
    Position Current { get; }
    Position Destination { get; }
    void Action(double time);
  }
}