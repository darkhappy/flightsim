using System;
using Simulator.Models.Airplanes;

namespace Simulator.Models.Tasks
{
  public class ClientPassenger : TaskTransport
  {
    public ClientPassenger(Airport airport) : base(airport)
    {
      Amount = Math.Round(new Random().NextDouble() * airport.PassengerTraffic * 5);
    }
  }
}