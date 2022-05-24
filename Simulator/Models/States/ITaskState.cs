using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  public interface ITaskState : IState
  {
    Task Task { get; }
  }
}