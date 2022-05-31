using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  [DataContract(Namespace = "")]
  [KnownType("GetDerivedTypes")]
  public abstract class Airplane
  {
    protected Airplane(string id, string name, int speed, int maintenanceTime, Airport origin)
    {
      Id = id;
      Name = name;
      Speed = speed;
      MaintenanceTime = maintenanceTime;
      Origin = origin;
      State = new StandbyState();
    }

    public IState State { get; }

    [DataMember] public string Id { get; private set; }

    [DataMember] public string Name { get; private set; }

    [DataMember] public int Speed { get; private set; }

    [DataMember] public int MaintenanceTime { get; private set; }

    public Airport Origin { get; set; }

    public abstract Colour Colour { get; }

    public void Action(double time)
    {
      State.Action(time);
    }

    public abstract void ChangeState();

    public abstract void ChangeState(Task task);

    public abstract bool AssignTask(Task task);

    private static Type[] GetDerivedTypes()
    {
      return Assembly.GetExecutingAssembly().GetTypes().Where(_ => _.IsSubclassOf(typeof(Airplane))).ToArray();
    }
  }
}