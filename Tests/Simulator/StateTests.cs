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
    [SetUp]
    public void Setup()
    {
      _firstAirport = new Airport("DS-01", "Death Star", new Position(0, 0), 100, 100);
    }

    private Airport _firstAirport;

    [Test]
    public void SwitchingWhenFinishedTimeState()
    {
      var plane = new ScoutPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var task = new TaskScout(new Position(100, 0));

      plane.AssignTask(task);
      plane.Action(4);

      Assert.That(plane.State, Is.TypeOf<StandbyState>());
    }

    [Test]
    public void StandbyActionDoesNotDoAnything()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      plane.Action(4124);

      Assert.That(plane.State, Is.TypeOf<StandbyState>());
    }

    [Test]
    public void MovingPlane()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var task = new TaskFight(new Position(400, 0));

      var state = new FightingFlight(plane, task);

      var result = state.CalculateDistance(4).Item1;
      var expectedPosition = new Position(400, 0);

      Assert.That(result, Is.EqualTo(expectedPosition));
    }

    [Test]
    public void PlaneHasPositionOutOfBoundsWhenStandby()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);

      Assert.That(plane.Position, Is.EqualTo(new Position(-1, -1)));
    }

    [Test]
    public void PlaneHasOriginPositionWhenPutOnState()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var task = new TaskFight(new Position(400, 0));

      plane.AssignTask(task);

      Assert.That(plane.Position, Is.EqualTo(new Position(0, 0)));
    }

    [Test]
    public void Overlap()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2, _firstAirport);
      var task = new TaskFight(new Position(400, 0));

      var state = new FightingFlight(plane, task);

      var resultOverlap = state.CalculateDistance(6).Item2;
      var expectedOverlap = 2;

      Assert.That(resultOverlap, Is.EqualTo(expectedOverlap));
    }
  }
}