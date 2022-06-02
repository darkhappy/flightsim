using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models
{
  [DataContract(Namespace = "")]
  public class Scenario : IExtensibleDataObject
  {
    private static Scenario _instance;

    public Scenario()
    {
      Airports = new List<Airport>();
      Tasks = new List<Task>();
      UnassignedTasks = new List<Task>();
    }

    [DataMember] public List<Airport> Airports { get; private set; }
    public List<Task> Tasks { get; private set; }
    public List<Task> UnassignedTasks { get; private set; }

    public static Scenario Instance => _instance ?? (_instance = new Scenario());

    public ExtensionDataObject ExtensionData { get; set; } = null!;

    public Airport GetFromPosition(Position position)
    {
      return Airports.Find(a => a.Position.Equals(position));
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      Tasks = new List<Task>();
      UnassignedTasks = new List<Task>();
    }

    public void GenerateTasks()
    {
      throw new NotImplementedException();
    }

    public void HandleTick(double time)
    {
      AssingUnassignedTasks();
    }

    private void AssingUnassignedTasks()
    {
      foreach (Task task in UnassignedTasks)
      {
        foreach (Airport airport in Airports)
        {
          airport.AssignTask(task);
        }
      }
    }

    public void RemoveTask(Task task)
    {
      throw new NotImplementedException();
    }

    public List<Airport> GetNearestAirports(Position position)
    {
      throw new NotImplementedException();
    }
  }
}