using System;
using Simulator.Models.Tasks;

namespace Simulator.Models.Airplanes
{
  public class RescuePlane : Airplane
  {
    public RescuePlane(string id, string name, int speed, int maintenanceTime, Airport origin) :
      base(id, name, speed, maintenanceTime, origin)
    {
    }

    public override Colour Colour => Colour.Red;

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