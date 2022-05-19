using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public abstract class TimedStateWithTask : TimedState, ITaskState
  {
    protected TimedStateWithTask(double time, Task task) : base(time)
    {
      Task = task;
    }

    public Task Task { get; }
  }
}