using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public class TaskTransport : Task
  {
    public TaskTransport(Position position) : base(position)
    {
    }

    public Airport Destination { get; }
  }
}