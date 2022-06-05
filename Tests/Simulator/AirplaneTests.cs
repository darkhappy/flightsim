using NUnit.Framework;
using Simulator.Models;
using Simulator.Models.Airplanes;
using Simulator.Models.States;
using Simulator.Models.Tasks;

namespace Tests.Simulator
{
  [TestFixture]
  public class AirplaneTests
  {
    [SetUp]
    public void Setup()
    {
      _firstAirport = new Airport("DS-01", "Death Star", new Position(0, 0), 100, 100);
      _secondAirport = new Airport("COR", "Coruscant", new Position(100, 0), 1000, 1000);
    }

    private Airport _firstAirport;
    private Airport _secondAirport;

    [Test]
    public void CanAssignToFighter()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var fight = new TaskFight(new Position(100, 100));

      Assert.That(plane.AssignTask(fight), Is.True);
    }

    [Test]
    public void CannotAssignFightToScout()
    {
      var plane = new ScoutPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var fight = new TaskFight(new Position(100, 100));

      Assert.That(plane.AssignTask(fight), Is.False);
    }

    [Test]
    public void CannotAssignDueToBusy()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var fight = new TaskFight(new Position(100, 100));
      var fight2 = new TaskFight(new Position(200, 100));
      plane.AssignTask(fight);

      Assert.That(plane.AssignTask(fight2), Is.False);
    }

    [Test]
    public void SwitchingFromIdleToScout()
    {
      var plane = new ScoutPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var scout = new TaskScout(new Position(100, 0));
      plane.AssignTask(scout);

      Assert.That(plane.State, Is.TypeOf<ScoutFlight>());
    }

    [Test]
    public void SwitchingFromScoutToMaintenance()
    {
      var plane = new ScoutPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var scout = new TaskScout(new Position(100, 0));
      plane.AssignTask(scout);
      plane.Action(2);

      Assert.That(plane.State, Is.TypeOf<MaintenanceState>());
    }

    [Test]
    public void SwitchingFromMaintenanceToIdle()
    {
      var plane = new ScoutPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var scout = new TaskScout(new Position(100, 0));
      plane.AssignTask(scout);
      plane.Action(2);
      plane.Action(2);

      Assert.That(plane.State, Is.TypeOf<StandbyState>());
    }
  }
}