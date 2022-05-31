using System;
using System.Runtime.Serialization;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  [DataContract(Namespace = "")]
  public abstract class TransportPlane : Airplane
  {
    protected TransportPlane(string id, string name, int speed, int maintenanceTime, Airport origin,
                             double maxCapacity, int embarkingTime, int disembarkingTime) : base(
      id, name, speed, maintenanceTime, origin)
    {
      MaxCapacity = maxCapacity;
      EmbarkingTime = embarkingTime;
      DisembarkingTime = disembarkingTime;
    }

    [DataMember] public double MaxCapacity { get; set; }
    [DataMember] public int EmbarkingTime { get; set; }
    [DataMember] public int DisembarkingTime { get; set; }

    public override void ChangeState()
    {
      throw new NotImplementedException();
    }

    public override void ChangeState(Task task)
    {
      throw new NotImplementedException();
    }

    public override bool AssignTask(Task task)
    {
      throw new NotImplementedException();
    }
  }
}