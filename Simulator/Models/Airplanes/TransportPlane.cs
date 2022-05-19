using System;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  public abstract class TransportPlane : Airplane
  {
    protected TransportPlane(string id, string name, Position position, int speed, int maintenanceTime, Airport origin,
                             double maxCapacity, int embarkingTime, int disembarkingTime) : base(
      id, name, position, speed, maintenanceTime, origin)
    {
      MaxCapacity = maxCapacity;
      EmbarkingTime = embarkingTime;
      DisembarkingTime = disembarkingTime;
    }

    public double MaxCapacity { get; set; }
    public int EmbarkingTime { get; set; }
    public int DisembarkingTime { get; set; }

    public override void ChangeState()
    {
      throw new NotImplementedException();
    }

    public override void ChangeState(Task task)
    {
      throw new NotImplementedException();
    }

    public override void AssignTask(Task task)
    {
      throw new NotImplementedException();
    }
  }
}