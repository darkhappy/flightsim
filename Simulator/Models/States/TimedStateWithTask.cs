using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public abstract class TimedStateWithTask : TimedState
  {
    protected TimedStateWithTask(Airplane plane, Task task) : base(plane)
    {
      Task = task;
    }

    protected Task Task { get; }
  }
}