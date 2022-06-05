using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  [DataContract(Namespace = "")]
  public class CargoPlane : TransportPlane
  {
    public CargoPlane(string id, string name, int speed, int maintenanceTime, Airport origin,
                      double maxCapacity, int embarkingTime, int disembarkingTime) : base(id, name,
      speed, maintenanceTime, origin, maxCapacity, embarkingTime, disembarkingTime)
    {
    }

    public override Colour Colour => Colour.Blue;

    protected override bool CanDoTask(Task task)
    {
      if (task.GetType() != typeof(ClientCargo)) return false;
      State = new EmbarkState(this, (TaskTransport) task);

      return true;
    }
  }
}