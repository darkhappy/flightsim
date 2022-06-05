using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  [DataContract(Namespace = "")]
  public class RescuePlane : Airplane
  {
    public RescuePlane(string id, string name, int speed, int maintenanceTime, Airport origin) :
      base(id, name, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Red;

    public override TaskType Type => TaskType.Rescue;

    protected override bool CanDoTask(Task task)
    {
      if (task.Type == Type) return false;
      State = new RescueFlight(this, task);

      return true;
    }
  }
}