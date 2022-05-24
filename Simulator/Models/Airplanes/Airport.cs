using System;
using System.Collections.Generic;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  public class Airport
  {
    private List<TaskTransport> _clients;

    public Airport(string id, string name, Position position, int passengerTraffic, double cargoTraffic)
    {
      Id = id;
      Name = name;
      Position = position;
      Airplanes = new List<Airplane>();
      _clients = new List<TaskTransport>();
      PassengerTraffic = passengerTraffic;
      CargoTraffic = cargoTraffic;
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public Position Position { get; set; }
    public int PassengerTraffic { get; set; }
    public double CargoTraffic { get; set; }
    public List<Airplane> Airplanes { get; }

    public void Action(double time)
    {
      throw new NotImplementedException();
    }

    public bool AssignTask(Task task)
    {
      throw new NotImplementedException();
    }
  }
}