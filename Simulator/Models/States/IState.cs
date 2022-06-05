namespace Simulator.Models.States
{
  public interface IState
  {
    Position Current { get; }
    void Action(double time);
  }
}