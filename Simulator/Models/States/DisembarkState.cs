using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public class DisembarkState : TimedStateWithTask
  {
    public DisembarkState(double time, Task task) : base(time, task)
    {
    }
  }
}