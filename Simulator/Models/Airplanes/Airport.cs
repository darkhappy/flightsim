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
      foreach (var airplane in Airplanes) airplane.Action(time);
    }

    public bool AssignTask(Task task)
    {
      return Airplanes.Any(airplane => airplane.AssignTask(task));
    }

    public void AddClient(TaskTransport task)
    {
      var taskToMerge = Clients.FirstOrDefault(t => t.Destination == task.Destination);
      if (taskToMerge != null)
      {
        task.Merge(taskToMerge);
        Clients.Remove(taskToMerge);
      }

      Clients.Add(task);
    }

    public List<string> GetToStringOfPlanes()
    {
      var list = new List<string>();
      foreach (var airplane in Airplanes)
      {
        list.Add(airplane.ToString());
      }

      return list;
    }
  }
}