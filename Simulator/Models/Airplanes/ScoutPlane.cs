using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  [DataContract(Namespace = "")]
  public class ScoutPlane : Airplane
  {
    public ScoutPlane(string id, string name, int speed, int maintenanceTime, Airport origin) : base(
      id, name, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Gray;

    protected override bool CanDoTask(Task task)
    {
      if (task.GetType() != typeof(TaskScout)) return false;
      State = new ScoutFlight(this, task);

      return true;
    }
  }
}