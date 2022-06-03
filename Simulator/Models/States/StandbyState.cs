using System;

namespace Simulator.Models.States
{
  public class StandbyState : IState
  {
    public void Action(double time)
    {
      throw new NotImplementedException();
    }
    public override string ToString()
    {
      return "Stand by";
    }
  }
}