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

    [Test]
    public void AssigningATransportPlaneATaskRemovesFromClientList()
    {
      var airport = new Airport("DS-01", "Death Star", new Position(0, 0), 100, 100);
      var plane = new CargoPlane("T-01", "Tie Fighter", 100, 2, airport, 100, 10, 10);
      var client = new ClientCargo(airport)
      {
        Amount = 100
      };

      airport.Airplanes.Add(plane);
      airport.AddClient(client);

      airport.Action(0);
      Assert.That(airport.Clients.Count, Is.EqualTo(0));
    }

    [Test]
    public void AssigningAClientWillChangeState()
    {
      var airport = new Airport("DS-01", "Death Star", new Position(0, 0), 100, 100);
      var plane = new CargoPlane("T-01", "Tie Fighter", 100, 2, airport, 100, 10, 10);
      var client = new ClientCargo(airport)
      {
        Amount = 100
      };

      airport.Airplanes.Add(plane);
      airport.AddClient(client);

      airport.Action(0);
      Assert.That(plane.State, Is.TypeOf<EmbarkState>());
    }

    [Test]
    public void AssigningAClientWithTooManyCargoWillSplit()
    {
      var airport = new Airport("DS-01", "Death Star", new Position(0, 0), 100, 100);
      var plane = new CargoPlane("T-01", "Tie Fighter", 100, 2, airport, 100, 10, 10);
      var client = new ClientCargo(airport)
      {
        Amount = 150
      };

      airport.Airplanes.Add(plane);
      airport.AddClient(client);

      airport.Action(0);
      Assert.That(airport.Clients.Count, Is.EqualTo(1));
    }

    [Test]
    public void AssigningAClientWithTooManyCargoWillOnlyEmbarkTheProperAmount()
    {
      var airport = new Airport("DS-01", "Death Star", new Position(0, 0), 100, 100);
      var plane = new CargoPlane("T-01", "Tie Fighter", 100, 2, airport, 100, 10, 10);
      var client = new ClientCargo(airport)
      {
        Amount = 150
      };

      airport.Airplanes.Add(plane);
      airport.AddClient(client);

      airport.Action(0);
      Assert.That(airport.Clients[0].Amount, Is.EqualTo(50));
    }

    [Test]
    public void AssigningAClientWillOnlyAssignToOneAirplane()
    {
      var airport = new Airport("DS-01", "Death Star", new Position(0, 0), 100, 100);
      var plane = new CargoPlane("T-01", "Tie Fighter", 100, 2, airport, 100, 10, 10);
      var plane2 = new CargoPlane("T-02", "Tie Fighter", 100, 2, airport, 100, 10, 10);
      var client = new ClientCargo(airport)
      {
        Amount = 100
      };

      airport.Airplanes.Add(plane);
      airport.Airplanes.Add(plane2);
      airport.AddClient(client);

      airport.Action(0);
      Assert.That(plane2.State, Is.TypeOf<StandbyState>());
    }
  }
}