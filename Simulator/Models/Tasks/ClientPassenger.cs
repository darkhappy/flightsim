using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public class ClientPassenger : TaskTransport
  {
    public ClientPassenger(Airport airport) : base(airport)
    {
    }

    public ClientPassenger(Position position) : base(position)
    {
    }
  }
}