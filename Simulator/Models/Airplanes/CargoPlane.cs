using System.Runtime.Serialization;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  /// <summary>
  /// Class that represents a Cargo Airplane.
  /// </summary>
  [DataContract(Namespace = "")]
  public class CargoPlane : TransportPlane
  {
    /// <summary>
    /// Constructor of Cargo airplane.
    /// </summary>
    /// <param name="id">Id.</param>
    /// <param name="name">Name</param>
    /// <param name="speed">Speed</param>
    /// <param name="maintenanceTime">Maintenance time.</param>
    /// <param name="origin">Origine airport.</param>
    /// <param name="maxCapacity">Max capacity</param>
    /// <param name="embarkingTime">Embarking time.</param>
    /// <param name="disembarkingTime">Disembarking time.</param>
    public CargoPlane(string id, string name, int speed, int maintenanceTime, Airport origin,
                      double maxCapacity, int embarkingTime, int disembarkingTime) : base(id, name,
      speed, maintenanceTime, origin, maxCapacity, embarkingTime, disembarkingTime)
    {
    }

    /// <summary>
    /// Getter for colour.
    /// </summary>
    public override Colour Colour => Colour.Blue;
    public override TaskType Type => TaskType.Cargo;

    /// <summary>
    /// Method returns true if it can do task.
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