namespace Simulator.Models.States
{
  public interface IState
  {
    void Action(double time);
  }
}