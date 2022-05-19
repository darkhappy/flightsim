using System;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  public class FightPlane : Airplane
  {
    public FightPlane(string id, string name, Position position, int speed, int maintenanceTime, Airport origin) : base(
      id, name, position, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Yellow;

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