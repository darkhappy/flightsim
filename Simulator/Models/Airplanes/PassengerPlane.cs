using System.Runtime.Serialization;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  [DataContract(Namespace = "")]
  public class PassengerPlane : TransportPlane
  {
    public PassengerPlane(string id, string name, int speed, int maintenanceTime, Airport origin,
                          double maxCapacity, int embarkingTime, int disembarkingTime) : base(id, name, speed,
      maintenanceTime, origin, maxCapacity, embarkingTime, disembarkingTime)
    {
    }

    public override Colour Colour => Colour.Green;

    protected override bool CanDoTask(Task task)
    {
      if (task.GetType() != typeof(ClientPassenger)) return false;

      LoadCargo((TaskTransport) task);

      return true;
    }
  }
}