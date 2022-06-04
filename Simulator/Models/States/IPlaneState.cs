using Simulator.Models.Airplanes;

namespace Simulator.Models.States
{
  public interface IPlaneState : IState
  {
    public Airplane Plane { get; }
  }
}