using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  /// <summary>
  /// Class that represents an airport.
  /// </summary>
  [DataContract(Namespace = "")]
  public class Airport : IExtensibleDataObject
  {
    /// <summary>
    /// Constructor of an airport.
    /// </summary>
    /// <param name="id">
    /// Data member : unique identifier as string.
    /// </param>
    /// <param name="name">
    /// Name of the airport as string.
    /// </param>
    /// <param name="position">
    /// Position of the airport in the map as Position type.
    /// </param>
    /// <param name="passengerTraffic">
    /// Traffic of passengers in the airport as int.
    /// </param>
    /// <param name="cargoTraffic">
    /// Traffic of cargo in the airport.
    /// </param>
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

    /// <summary>
    /// Getter and Setter of clients.
    /// </summary>
    public List<TaskTransport> Clients { get; set; }

    /// <summary>
    /// Property : unique identifier as string.
    /// </summary>
    [DataMember]
    public string Id { get; private set; }

    /// <summary>
    /// Property : name of airport as string.
    /// </summary>
    [DataMember]
    public string Name { get; private set; }

    /// <summary>
    /// Property : Position of the airport on the map as a Position type.
    /// </summary>
    [DataMember]
    public Position Position { get; private set; }

    /// <summary>
    /// Traffic of passengers in the airport as int.
    /// </summary>
    [DataMember]
    public int PassengerTraffic { get; private set; }

    /// <summary>
    /// Traffic of cargo in the airport as double.
    /// </summary>
    [DataMember]
    public double CargoTraffic { get; private set; }

    /// <summary>
    /// Getter setter of list of airplanes.
    /// </summary>
    [DataMember]
    public List<Airplane> Airplanes { get; private set; }

    /// <summary>
    /// Returns or sets the estention data object.
    /// </summary>
    public ExtensionDataObject ExtensionData { get; set; } = null!;

    /// <summary>
    /// Method used for desirializing.
    /// </summary>
    /// <param name="context">
    /// Context.
    /// </param>
    [OnDeserialized]
    public void OnDeserialized(StreamingContext context)
    {
      Clients = new List<TaskTransport>();
      foreach (var airplane in Airplanes) airplane.Origin = this;
    }

    /// <summary>
    /// Methon to make all airplanes make their actions.
    /// </summary>
    /// <param name="time">
    /// Time as double.
    /// </param>
    public void Action(double time)
    {
      foreach (var airplane in Airplanes.ToList())
      {
        foreach (var client in Clients.ToList().Where(client => airplane.AssignTask(client))) Clients.Remove(client);

        airplane.Action(time);
      }
    }

    /// <summary>
    /// Method that returns all flying airplanes.
    /// </summary>
    /// <returns>A list of airplanes.</returns>
    public IEnumerable<Tuple<string, TaskType, Position, Position, Position>> GetFlyingAirplanes()
    {
      return (from airplane in Airplanes
              where !airplane.Position.Hidden
              select new Tuple<string, TaskType, Position, Position, Position>(airplane.Id, airplane.Type,
                airplane.Position,
                airplane.OriginPosition, airplane.Destination)).ToList();
    }

    /// <summary>
    /// Method that assigns a specified task to an availlable airplane.
    /// </summary>
    /// <param name="task">A task.</param>
    /// <returns>Bool</returns>
    public bool AssignTask(Task task)
    {
      if (!Airplanes.Any(airplane => airplane.AssignTask(task))) return false;

      // Remove task from clients
      if (task is TaskTransport taskTransport) Clients.Remove(taskTransport);
      return true;
    }

    /// <summary>
    /// Method to add clients to airport.
    /// </summary>
    /// <param name="task">Transport task.</param>
    public void AddClient(TaskTransport task)
    {
      var taskToMerge = Clients.FirstOrDefault(t => t.Destination == task.Destination && t.Type == task.Type);
      if (taskToMerge != null)
        if (task.Merge(taskToMerge))
          Clients.Remove(taskToMerge);

      Clients.Add(task);
    }

    /// <summary>
    /// Method that returns a list of all airplane's ToString()."/>
    /// </summary>
    /// <returns>A list of string.</returns>
    public List<string> GetToStringOfPlanes()
    {
      return Airplanes.Select(airplane => airplane.ToString()).ToList();
    }

    /// <summary>
    /// Method that splits clients for different airplanes.
    /// </summary>
    /// <param name="client">Transport client.</param>
    /// <param name="remainder">No</param>
    public void SplitClient(TaskTransport client, double remainder)
    {
      Clients.Add(client.Split(remainder));
    }

    /// <summary>
    /// Method that returns all clients of the airport.
    /// </summary>
    /// <returns>List of clients.</returns>
    public List<string> GetClients()
    {
      return Clients.Select(client => client.ToString()).ToList();
    }

    /// <summary>
    /// Method that transfers an airplane to another airport.
    /// </summary>
    /// <param name="destination">Airport destination.</param>
    /// <param name="airplane">Airplane to transfer.</param>
    public void TransferTo(Airport destination, Airplane airplane)
    {
      Airplanes.Remove(airplane);
      destination.Airplanes.Add(airplane);
      airplane.Origin = destination;
    }
  }
}