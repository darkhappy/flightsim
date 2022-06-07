using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  /// <summary>
  /// Class of a rescue airplane.
  /// </summary>
  [DataContract(Namespace = "")]
  public class RescuePlane : Airplane
  {
    /// <summary>
    /// Constructor of a rescue airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="speed"></param>
    /// <param name="maintenanceTime"></param>
    /// <param name="origin"></param>
    public RescuePlane(string id, string name, int speed, int maintenanceTime, Airport origin) :
      base(id, name, speed, maintenanceTime, origin)
    {
    }

    /// <summary>
    /// Getter of the task type.
    /// </summary>
    public override TaskType Type => TaskType.Rescue;

    /// <summary>
    /// Returns true if airplane can do task.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    protected override bool CanDoTask(Task task)
    {
      if (task.Type != Type) return false;
      State = new RescueFlight(this, task);

      return true;
    }
  }
}