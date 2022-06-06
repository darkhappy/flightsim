namespace Simulator.Models.States
{
  /// <summary>
  /// Interface of a State.
  /// </summary>
  public interface IState
  {
    Position Current { get; }
    Position Destination { get; }
    void Action(double time);
  }
}