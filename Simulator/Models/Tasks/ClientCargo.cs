using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public class ClientCargo : TaskTransport
  {
    public ClientCargo(Airport airport) : base(airport)
    {
    }

    public ClientCargo(Position position) : base(position)
    {
    }
  }
}