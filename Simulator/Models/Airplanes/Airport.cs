using System;
using System.Collections.Generic;
using System.Linq;
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

    public List<TaskTransport> Clients { get; set; }

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
      foreach (var airplane in Airplanes)
      {
        foreach (var client in Clients.ToList().Where(client => airplane.AssignTask(client))) Clients.Remove(client);

        airplane.Action(time);
      }
    }

    public List<Tuple<TaskType, Position, Position, Position>> GetFlyingAirplanes()
    {
      return (from airplane in Airplanes
              where !airplane.Position.Hidden
              select new Tuple<TaskType, Position, Position, Position>(airplane.Type, airplane.Position,
                airplane.OriginPosition, airplane.Destination)).ToList();
    }

    public bool AssignTask(Task task)
    {
      if (!Airplanes.Any(airplane => airplane.AssignTask(task))) return false;

      // Remove task from clients
      if (task is TaskTransport taskTransport) Clients.Remove(taskTransport);
      return true;
    }

    public void AddClient(TaskTransport task)
    {
      var taskToMerge = Clients.FirstOrDefault(t => t.Destination == task.Destination);
      if (taskToMerge != null && task.Merge(taskToMerge))
        Clients.Remove(taskToMerge);

      Clients.Add(task);
    }

    public List<string> GetToStringOfPlanes()
    {
      return Airplanes.Select(airplane => airplane.ToString()).ToList();
    }

    public void SplitClient(TaskTransport client, double remainder)
    {
      var newClient = client.Split(remainder);

      Clients.Add(newClient);
    }
  }
}