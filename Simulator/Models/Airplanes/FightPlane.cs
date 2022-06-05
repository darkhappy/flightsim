using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  [DataContract(Namespace = "")]
  public class FightPlane : Airplane
  {
    public FightPlane(string id, string name, int speed, int maintenanceTime, Airport origin) : base(
      id, name, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Yellow;
    public override TaskType Type => TaskType.Fight;


    protected override bool CanDoTask(Task task)
    {
      if (task.GetType() != typeof(TaskFight)) return false;
      State = new FightingFlight(this, task);

      return true;
    }
  }
}