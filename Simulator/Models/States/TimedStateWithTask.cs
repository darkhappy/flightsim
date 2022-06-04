using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public abstract class TimedStateWithTask : TimedState, ITaskState
  {
    protected TimedStateWithTask(Airplane plane, Task task) : base(plane)
    {
      Task = task;
    }

    public Task Task { get; }

    public override string ToString()
    {
      return "Timed with task";
    }
  }
}