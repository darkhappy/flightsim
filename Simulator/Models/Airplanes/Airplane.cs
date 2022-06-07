using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  /// <summary>
  ///   Abstract class representing an airplane in the simulation.
  /// </summary>
  [DataContract(Namespace = "")]
  [KnownType("GetDerivedTypes")]
  public abstract class Airplane
  {
    /// <summary>
    ///   Constructor for the <see cref="Airplane" /> class.
    /// </summary>
    protected Airplane(string id, string name, int speed, int maintenanceTime, Airport origin)
    {
      Id = id;
      Name = name;
      Speed = speed;
      MaintenanceTime = maintenanceTime;
      Origin = origin;
      State = new StandbyState();
    }

    /// <summary>
    /// Represents the state of the airplane. 
    /// </summary>
    public IState State { get; set; }

    /// <summary>
    ///   Represents the unique identifier for the <see cref="Airplane" />.
    /// </summary>
    [DataMember]
    public string Id { get; private set; }

    /// <summary>
    ///   Represents the name of the <see cref="Airplane" />.
    /// </summary>
    [DataMember]
    public string Name { get; private set; }

    /// <summary>
    ///   Represents the speed at which the <see cref="Airplane" /> can travel.
    /// </summary>
    [DataMember]
    public int Speed { get; private set; }

    /// <summary>
    ///   Represents the time it takes to perform maintenance on the <see cref="Airplane" />.
    /// </summary>
    [DataMember]
    public int MaintenanceTime { get; private set; }

    /// <summary>
    /// Method that returns the task type that the airplane can take.
    /// </summary>
    public abstract TaskType Type { get; }

    /// <summary>
    /// Gets and Sets the origin Airport of the airplane.
    /// </summary>
    public Airport Origin { get; set; }

    /// <summary>
    /// Sets the origine position of the airplane.
    /// </summary>
    public Position OriginPosition => Origin.Position;

    /// <summary>
    /// Sets the current position when moving on the map.
    /// </summary>
    public Position Position => State.Current;

    /// <summary>
    /// Sets the destionation position of the airplane.
    /// </summary>
    public Position Destination => State.Destination;

    /// <summary>
    /// Sets the state of the plane to standby when desirialized.
    /// </summary>
    /// <param name="context"></param>
    [OnDeserialized]
    private void OnDeserialized(StreamingContext context)
    {
      State = new StandbyState();
    }

    /// <summary>
    /// Make the actions determined by the state during the specified time laps.
    /// </summary>
    /// <param name="time">
    /// The time laps.
    /// </param>
    public void Action(double time)
    {
      State.Action(time);
    }

    /// <summary>
    /// Assigns a specified task to an airplane. 
    /// </summary>
    /// <param name="task">
    /// The task.
    /// </param>
    /// <returns>
    /// Returns true if the task is assignable to the airplane.
    /// </returns>
    public bool AssignTask(Task task)
    {
      return State.GetType() == typeof(StandbyState) && CanDoTask(task);
    }

    /// <summary>
    /// Returns true if the plane can do the specified task.
    /// </summary>
    /// <param name="task">
    /// The specified task.
    /// </param>
    /// <returns>
    /// A boolean.
    /// </returns>
    protected abstract bool CanDoTask(Task task);

    /// <summary>
    /// Used for deserialization.
    /// </summary>
    private static Type[] GetDerivedTypes()
    {
      return Assembly.GetExecutingAssembly().GetTypes()
        .Where(_ => _.IsSubclassOf(typeof(Airplane))).ToArray();
    }

    /// <summary>
    /// ToString override for task.
    /// </summary>
    /// <returns>
    /// A string that represents the state.
    /// </returns>
    public override string ToString()
    {
      return $"{Name} ({Id}) - {State.ToString()}";
    }

    /// <summary>
    /// Transfers airplane to another airport.
    /// </summary>
    /// <param name="destination">
    /// The airport to be replaced.
    /// </param>
    public void TransferTo(Airport destination)
    {
      Origin.TransferTo(destination, this);
    }
  }
}