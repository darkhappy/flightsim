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
    private Airport _firstAirport;
    private Airport _secondAirport;

    [SetUp]
    public void Setup()
    {
      _firstAirport = new Airport("DS-01", "Death Star", new Position(50, 50), 100, 100);
      _secondAirport = new Airport("COR", "Coruscant", new Position(0, 0), 1000, 1000);
    }

    [Test]
    public void PlaneIsInAirport()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      Assert.That(_firstAirport.Airplanes, Contains.Item(plane));
    }
    
    [Test]
    public void PlaneIsNotInAirport()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      Assert.That(_secondAirport.Airplanes, Contains.Item(plane));
    }

    [Test]
    public void CanAssignToFighter()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var fight = new TaskFight(new Position(100, 100));
      
      Assert.That(plane.AssignTask(fight), Is.True);
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
    public void SwitchingFromIdleToFight()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var fight = new TaskFight(new Position(100, 100));
      plane.AssignTask(fight);
      
      Assert.That(plane.State, Is.TypeOf<FightingFlight>());
    }

    [Test]
    public void SwitchingFromFightToMaintenance()
    {
      
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var fight = new TaskFight(new Position(100, 100));
      plane.AssignTask(fight);
      
      plane.ChangeState();
      Assert.That(plane.State, Is.TypeOf<MaintenanceState>());
    }

    [Test]
    public void SwitchingFromMaintenanceToIdle()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var fight = new TaskFight(new Position(100, 100));
      plane.AssignTask(fight);
      
      plane.ChangeState();
      plane.ChangeState();
      Assert.That(plane.State, Is.TypeOf<MaintenanceState>());
    }
  }
}
