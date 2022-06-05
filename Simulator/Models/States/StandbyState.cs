namespace Simulator.Models.States
{
  public class StandbyState : IState
  {
    public void Action(double time)
    {
      Destination = new Position(-1, -1);
    }

    public Position Current => new Position(-1, -1);
    public virtual Position Destination { get; set; }


    public override string ToString()
    {
      return "Stand by";
    }
  }
}