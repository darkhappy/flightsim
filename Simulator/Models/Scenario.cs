using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Simulator.Controllers;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Simulator.Models
{
  /// <summary>
  ///   Represents a scenario.
  /// </summary>
  [DataContract(Namespace = "")]
  public class Scenario : IExtensibleDataObject
  {
    /// <summary>
    ///   The instance of the scenario.
    /// </summary>
    private static Scenario? _instance;

    /// <summary>
    ///   Initializes a new instance of the <see cref="Scenario" /> class.
    /// </summary>
    public Scenario()
    {
      Airports = new List<Airport>();
      Tasks = new List<Task>();
      UnassignedTasks = new List<Task>();
    }

    /// <summary>
    ///   Represents a list of airports.
    /// </summary>
    [DataMember]
    public List<Airport> Airports { get; private set; }

    /// <summary>
    ///   Represents a list of tasks.
    /// </summary>
    public List<Task> Tasks { get; private set; }

    /// <summary>
    ///   Represents a list of unassigned tasks.
    /// </summary>
    public List<Task> UnassignedTasks { get; private set; }

    /// <summary>
    ///   Gets the instance of the scenario. If the instance is not created yet, it will be created.
    /// </summary>
    public static Scenario Instance => _instance ??= new Scenario();

    /// <summary>
    ///   Used to deserialize the scenario.
    /// </summary>
    public ExtensionDataObject ExtensionData { get; set; } = null!;

    /// <summary>
    ///   Used to deserialize the scenario.
    /// </summary>
    /// <exception cref="Exception">Thrown when there are less than two airports.</exception>
    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      Tasks = new List<Task>();
      UnassignedTasks = new List<Task>();
      if (Airports.Count < 2) throw new Exception("Cannot create scenario with less than 2 airports.");
      _instance = this;
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
    public List<string> GetClients(string id)
    {
      var airport = GetAirport(id);
      return airport == null ? new List<string>() : airport.GetClients();
    }

    /// <summary>
    ///   Gets a list of all events that arent transport events.
    /// </summary>
    /// <returns>A list of all events that arent transport events.</returns>
    public List<Tuple<TaskType, Position>> GetEvents()
    {
      return (from task in Tasks
              where !task.IsTransportTask
              select new Tuple<TaskType, Position>(task.Type, task.Position)).ToList();
    }

    /// <summary>
    ///   Returns information about all flying airplanes.
    /// </summary>
    /// <returns>Returns the ID, the plane type, the position of the airplane, the task's origin and the task's destination.</returns>
    public List<Tuple<string, TaskType, Position, Position, Position>> GetFlyingAirplanes()
    {
      return Airports.SelectMany(airport => airport.GetFlyingAirplanes()).ToList();
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

    /// <summary>
    ///   Method that returns a list of all the airplanes of a given airport.
    /// </summary>
    /// <param name="id">The airport's ID</param>
    /// <returns>Each plane's information (their name and their state)</returns>
    public List<string> GetAirplanesFromAirport(string id)
    {
      var airport = GetAirport(id);
      return airport == null ? new List<string>() : airport.GetToStringOfPlanes();
    }

    /// <summary>
    ///   Gets the information of a given airport
    /// </summary>
    /// <returns>The ID and the Name of a given airport</returns>
    public List<ObjectInfo> GetAirportsObjectInfo()
    {
      return Airports.Select(airport => new ObjectInfo(airport.Id, airport.Name)).ToList();
    }

    /// <summary>
    ///   Handles a tick.
    /// </summary>
    /// <param name="time">The amount of time to handle.</param>
    public void HandleTick(double time)
    {
      AssignUnassignedTasks();

      foreach (var airport in Airports)
        airport.Action(time * 0.001);
    }

    /// <summary>
    ///   Tries to assign each unassigned task to an airplane.
    /// </summary>
    private void AssignUnassignedTasks()
    {
      for (var i = UnassignedTasks.Count - 1; i >= 0; i--)
      {
        if (GetNearestAirports(UnassignedTasks[i].Position).Any(airport => airport.AssignTask(UnassignedTasks[i])))
          UnassignedTasks.RemoveAt(i);
      }
    }

    /// <summary>
    ///   Removes a task from the task list.
    /// </summary>
    /// <param name="task"></param>
    public void RemoveTask(Task task)
    {
      Tasks.Remove(task);
      UnassignedTasks.Remove(task);
    }

    /// <summary>
    ///   Orders the airports by their distance to the given position.
    /// </summary>
    /// <param name="position">The position to use as a reference</param>
    /// <returns>A list of airports ordered by their distance to the given position</returns>
    public List<Airport> GetNearestAirports(Position position)
    {
      return Airports.OrderBy(airport => airport.Position.DistanceTo(position)).ToList();
    }

    /// <summary>
    ///   Adds a task to the task list.
    /// </summary>
    /// <param name="task">The task to add</param>
    /// <param name="addToUnassigned">True if the task should be added to the unassigned tasks list</param>
    public void AddTask(Task task, bool addToUnassigned = false)
    {
      Tasks.Add(task);
      if (addToUnassigned)
        UnassignedTasks.Add(task);
    }
  }
}