using Simulator.Models.Tasks;

namespace Simulator.Models.States
{
  /// <summary>
  /// Interface of Task state.
  /// </summary>
  public interface ITaskState : IState
  {
    Task Task { get; }
  }
}