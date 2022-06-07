using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  /// <summary>
  /// Class of a fight airplane.
  /// </summary>
  [DataContract(Namespace = "")]
  public class FightPlane : Airplane
  {
    /// <summary>
    /// Constructor of fight airplane.
    /// </summary>
    /// <param name="id"></param>
    /// <param name="name"></param>
    /// <param name="speed"></param>
    /// <param name="maintenanceTime"></param>
    /// <param name="origin"></param>
    public FightPlane(string id, string name, int speed, int maintenanceTime, Airport origin) : base(
      id, name, speed, maintenanceTime, origin)
    {
    }

    /// <summary>
    /// Getter of task type.
    /// </summary>
    public override TaskType Type => TaskType.Fight;

    /// <summary>
    /// Returns true if fight airplane can do task.
    /// </summary>
    /// <param name="task"></param>
    /// <returns></returns>
    protected override bool CanDoTask(Task task)
    {
      if (task.Type != Type) return false;
      State = new FightingFlight(this, task);

      return true;
    }
  }
}