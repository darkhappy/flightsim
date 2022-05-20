using NUnit.Framework;
using Simulator.Models;
using Simulator.Models.Airplanes;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Tests.Simulator
{
  [TestFixture]
  public class StateTests
  {
    private Airport _firstAirport;

    [SetUp]
    public void Setup()
    {
      _firstAirport = new Airport("DS-01", "Death Star", new Position(50, 50), 100, 100);
    }
    
    [Test]
    public void SwitchingWhenFinishedTimeState()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var task = new TaskFight(new Position(420, 420));

      plane.AssignTask(task);
      plane.ChangeState();
      plane.Action(2);
      
      Assert.That(plane.State, Is.TypeOf<StandbyState>());
    }

    [Test]
    public void StandbyActionDoesNotDoAnything()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      plane.Action(4124);
      
      Assert.That(plane.State, Is.TypeOf<StandbyState>());
    }
  }
}