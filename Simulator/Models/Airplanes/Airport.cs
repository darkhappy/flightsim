using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  [DataContract(Namespace = "")]
  public class Airport : IExtensibleDataObject
  {
    public Airport(string id, string name, Position position, int passengerTraffic, double cargoTraffic)
    {
      Id = id;
      Name = name;
      Position = position;
      Airplanes = new List<Airplane>();
      Clients = new List<TaskTransport>();
      PassengerTraffic = passengerTraffic;
      CargoTraffic = cargoTraffic;
    }

    public List<TaskTransport> Clients { get; private set; }

    [DataMember] public string Id { get; private set; }
    [DataMember] public string Name { get; private set; }
    [DataMember] public Position Position { get; private set; }
    [DataMember] public int PassengerTraffic { get; private set; }
    [DataMember] public double CargoTraffic { get; private set; }
    [DataMember] public List<Airplane> Airplanes { get; private set; }

    public ExtensionDataObject ExtensionData { get; set; } = null!;

    [OnDeserialized]
    public void OnDeserialized(StreamingContext context)
    {
      Clients = new List<TaskTransport>();
      foreach (var airplane in Airplanes) airplane.Origin = this;
    }

    public void Action(double time)
    {
      throw new NotImplementedException();
    }

    public bool AssignTask(Task task)
    {
      /*
      foreach (Airplane airplane in Airplanes)
      {
        if (airplane.State.ToString() == "StandBy")
        {

        }
      }
      */
      throw new NotImplementedException();
    }
  }
}