using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Generator.Models;
using Simulator.Controllers;
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

    public static Scenario Instance => _instance ??= new Scenario();

    public ExtensionDataObject ExtensionData { get; set; } = null!;

    public Airport GetFromPosition(Position position)
    {
      var airport = Airports.FirstOrDefault(a => a.Position.Equals(position));
      return airport;
    }

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      Tasks = new List<Task>();
      UnassignedTasks = new List<Task>();
    }

    /// <summary>
    /// Generates tasks when called.
    /// </summary>
    public void GenerateTasks()
    {
      var randFights = new Random().Next(1, Constants.MaxFightsPerHour);
      var randScouts = new Random().Next(1, Constants.MaxScoutsPerHour);
      var randRescues = new Random().Next(1, Constants.MaxRescuePerHour);
      var randCargos = new Random().Next(1, Constants.MaxCargoPerHour);
      var randPassengers = new Random().Next(1, Constants.MaxPassengersPerHour);

      for (var i = 0; i < randFights; i++)
      {
        var task = TaskFactory.Instance.CreateFightTask();
        Tasks.Add(task);
        UnassignedTasks.Add(task);
      }

      for (var i = 0; i < randScouts; i++)
      {
        var task = TaskFactory.Instance.CreateScoutTask();
        Tasks.Add(task);
        UnassignedTasks.Add(task);
      }

      for (var i = 0; i < randRescues; i++)
      {
        var task = TaskFactory.Instance.CreateRescueTask();
        Tasks.Add(task);
        UnassignedTasks.Add(task);
      }

      for (var i = 0; i < randCargos; i++)
      {
        var (origin, destination) = GetTwoUniqueAirports();

        var task = TaskFactory.Instance.CreateCargoTask(destination);
        Tasks.Add(task);
        origin.AddClient(task);
      }

      for (var i = 0; i < randPassengers; i++)
      {
        var (origin, destination) = GetTwoUniqueAirports();

        var task = TaskFactory.Instance.CreatePassengerTask(destination);
        Tasks.Add(task);
        origin.AddClient(task);
      }
    }

    /// <summary>
    /// Method that returns a list of all clients as a descriptive string.
    /// </summary>
    /// <returns>
    /// A list of all clients as a descriptive string.
    /// </returns>
    internal List<string> GetClients()
    {
      var list = new List<string>();
      foreach (var task in Tasks)
      {
        list.Add(task.ToString());
      }
      return list;
    }

    /// <summary>
    /// Method that returns two different airports.
    /// </summary>
    /// <returns>
    /// Returns a Tuple of two airports.
    /// </returns>
    private Tuple<Airport, Airport> GetTwoUniqueAirports()
    {
      var airport1 = Airports[new Random().Next(0, Airports.Count)];
      var airport2 = Airports[new Random().Next(0, Airports.Count)];
      while (airport2.Equals(airport1)) airport2 = Airports[new Random().Next(0, Airports.Count)];

      return new Tuple<Airport, Airport>(airport1, airport2);
    }

    /// <summary>
    /// Mothod to get an airport that has the given unique code.
    /// </summary>
    /// <param name="airportCode">
    /// Unique code of an airport.
    /// </param>
    /// <returns>
    /// An airport.
    /// </returns>
    private Airport? GetAirport(string airportCode)
    {
      return Airports.FirstOrDefault(a => a.Id == airportCode);
    }

    public List<string> GetAirplanesFromAirport(string id)
    {
      var airport = GetAirport(id);
      return airport.GetToStringOfPlanes();
    }

    public List<ObjectInfo> GetAirportsObjectInfo()
    {
      var list = new List<ObjectInfo>();
      foreach (var airport in Airports)
      {
        list.Add(new ObjectInfo(airport.Id, airport.Name));
      }
      return list;
    }



    public void HandleTick(double time)
    {
      //AssignUnassignedTasks();
    }

    private void AssignUnassignedTasks()
    {
      foreach (var task in UnassignedTasks)
      {
        foreach (var airport in Airports)
        {
          airport.AssignTask(task);
        }
      }
    }

    public void RemoveTask(Task task)
    {
      Tasks.Remove(task);
    }

    public List<Airport> GetNearestAirports(Position position)
    {
      throw new NotImplementedException();
    }
  }
}