using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public class EmbarkState : TimedStateWithTask
  {
    public EmbarkState(double time, Task task) : base(time, task)
    {
    }
  }
}