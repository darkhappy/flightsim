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
    private static Scenario? _instance;

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

    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      Tasks = new List<Task>();
      UnassignedTasks = new List<Task>();
      if (Airports.Count < 2) throw new Exception("Cannot create scenario with less than 2 airports.");
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
      return Tasks.Select(task => task.ToString()).ToList();
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
      return airport == null ? new List<string>() : airport.GetToStringOfPlanes();
    }

    public List<ObjectInfo> GetAirportsObjectInfo()
    {
      return Airports.Select(airport => new ObjectInfo(airport.Id, airport.Name)).ToList();
    }


    public void HandleTick(double time)
    {
      GenerateTasks();
      AssignUnassignedTasks();
    }

    private void AssignUnassignedTasks()
    {
      for (int i = UnassignedTasks.Count - 1; i >= 0; i--)
      {
        foreach (Airport airport in GetNearestAirports(UnassignedTasks[i].Position))
        {
          if (airport.AssignTask(UnassignedTasks[i]))
          {
            UnassignedTasks.RemoveAt(i);
            break;
          }
        }
      }
    }

    public void RemoveTask(Task task)
    {
      Tasks.Remove(task);
    }

    public List<Airport> GetNearestAirports(Position position)
    {
      return Airports.OrderBy(airport => airport.Position.DistanceTo(position)).ToList();
    }
  }
}