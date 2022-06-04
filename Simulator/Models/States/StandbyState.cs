namespace Simulator.Models.States
{
  public class StandbyState : IState
  {
    public void Action(double time)
    {
    }

    public override string ToString()
    {
      return "Stand by";
    }
  }
}