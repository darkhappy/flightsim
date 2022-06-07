using System.Runtime.Serialization;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  /// <summary>
  /// Class of a passenger transport airplane.
  /// </summary>
  [DataContract(Namespace = "")]
  public class PassengerPlane : TransportPlane
  {
    /// <summary>
    /// Constructor of a passenger transport airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="speed"></param>
    /// <param name="maintenanceTime"></param>
    /// <param name="origin"></param>
    /// <param name="maxCapacity"></param>
    /// <param name="embarkingTime"></param>
    /// <param name="disembarkingTime"></param>
    public PassengerPlane(string id, string name, int speed, int maintenanceTime, Airport origin,
                          double maxCapacity, int embarkingTime, int disembarkingTime) : base(id, name, speed,
      maintenanceTime, origin, maxCapacity, embarkingTime, disembarkingTime)
    {
    }

    /// <summary>
    /// Getter of task type.
    /// </summary>
    public override TaskType Type => TaskType.Passenger;

    /// <summary>
    /// Returns true if airplane can do the task.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    protected override bool CanDoTask(Task task)
    {
      if (task.Type != Type) return false;
      LoadClient((TaskTransport) task);

      return true;
    }
  }
}