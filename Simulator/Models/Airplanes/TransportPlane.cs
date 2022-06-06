using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  /// <summary>
  /// Abstract class of a transport airplane.
  /// </summary>
  [DataContract(Namespace = "")]
  public abstract class TransportPlane : Airplane
  {
    /// <summary>
    /// Constructor of base transport airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="speed"></param>
    /// <param name="maintenanceTime"></param>
    /// <param name="origin"></param>
    /// <param name="maxCapacity"></param>
    /// <param name="embarkingTime"></param>
    /// <param name="disembarkingTime"></param>
    protected TransportPlane(string id, string name, int speed, int maintenanceTime, Airport origin,
                             double maxCapacity, int embarkingTime, int disembarkingTime) : base(
      id, name, speed, maintenanceTime, origin)
    {
      MaxCapacity = maxCapacity;
      EmbarkingTime = embarkingTime;
      DisembarkingTime = disembarkingTime;
    }

    [DataMember] public double MaxCapacity { get; set; }
    [DataMember] public int EmbarkingTime { get; set; }
    [DataMember] public int DisembarkingTime { get; set; }

    /// <summary>
    /// Method to load client to transport airplane. 
    /// </summary>
    /// <param name="task"></param>
    protected void LoadClient(TaskTransport task)
    {
      // Check if there is enough people to make it worth transporting
      if (task.Amount > MaxCapacity) Origin.SplitClient(task, MaxCapacity);

      State = new EmbarkState(this, task);
    }
  }
}