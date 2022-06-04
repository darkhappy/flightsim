using System;
using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public class ClientCargo : TaskTransport
  {
    public ClientCargo(Airport airport) : base(airport)
    {
      Amount = (new Random().NextDouble() * airport.CargoTraffic + 1) * 5;
    }
    public override string ToString() => Amount + " tons of cargo to " + Destination.Name;
  }
}