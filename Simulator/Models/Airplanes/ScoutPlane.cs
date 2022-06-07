using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  /// <summary>
  /// Class of a scout airplane.
  /// </summary>
  [DataContract(Namespace = "")]
  public class ScoutPlane : Airplane
  {
    /// <summary>
    /// Constructor of scout airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="speed"></param>
    /// <param name="maintenanceTime"></param>
    /// <param name="origin"></param>
    public ScoutPlane(string id, string name, int speed, int maintenanceTime, Airport origin) : base(
      id, name, speed, maintenanceTime, origin)
    {
    }

    /// <summary>
    /// Returns task type of airplane.
    /// </summary>
    public override TaskType Type => TaskType.Scout;

    /// <summary>
    /// Returns true if airplane can do task.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    protected override bool CanDoTask(Task task)
    {
      if (task.Type != Type) return false;
      State = new ScoutFlight(this, task);

      return true;
    }
  }
}