namespace Simulator.Models.States
{
  public class StandbyState : IState
  {
    public void Action(double time)
    {
    }

    public Position Current => new Position(-1, -1);
    public Position Destination => new Position(-1, -1);


    public override string ToString()
    {
      return "Stand by";
    }
  }
}