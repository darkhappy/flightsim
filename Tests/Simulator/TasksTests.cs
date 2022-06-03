using NUnit.Framework;
using Simulator.Models;
using Simulator.Models.Airplanes;
using Simulator.Models.Tasks;

namespace Tests.Simulator
{
  [TestFixture]
  public class TasksTests
  {
    [SetUp]
    public void SetUp()
    {
      _scenario = Scenario.Instance;
      _airport = new Airport("CRS", "Coruscant", new Position(0, 0), 40, 40);
      _scenario.Airports.Add(_airport);
    }

    private Scenario _scenario;
    private Airport _airport;

    [Test]
    public void MergingTwoClientsHasProperAmount()
    {
      var clientOne = TaskFactory.Instance.CreatePassengerTask(_airport);
      var clientTwo = TaskFactory.Instance.CreatePassengerTask(_airport);

      clientOne.Amount = 40;
      clientTwo.Amount = 20;

      var result = clientOne.Merge(clientTwo);

      Assert.That(result.Amount, Is.EqualTo(60));
    }

    [Test]
    public void MergingTwoClientsHasProperDestination()
    {
      var clientOne = TaskFactory.Instance.CreatePassengerTask(_airport);
      var clientTwo = TaskFactory.Instance.CreatePassengerTask(_airport);

      var result = clientOne.Merge(clientTwo);

      Assert.That(result.Destination, Is.EqualTo(_airport));
    }

    [Test]
    public void CannotMergeTwoClientsWithSameDestination()
    {
      var otherAirport = new Airport("DS-01", "Death Star", new Position(0, 0), 40, 40);
      var clientOne = TaskFactory.Instance.CreatePassengerTask(_airport);
      var clientTwo = TaskFactory.Instance.CreatePassengerTask(otherAirport);

      void MergeClients()
      {
        clientOne.Merge(clientTwo);
      }

      Assert.That(MergeClients, Throws.ArgumentException);
    }

    [Test]
    public void MergingTwoClientsRemovesTheOtherFromAirport()
    {
      var clientOne = TaskFactory.Instance.CreatePassengerTask(_airport);
      var clientTwo = TaskFactory.Instance.CreatePassengerTask(_airport);

      _airport.AddClient(clientOne);
      _airport.AddClient(clientTwo);

      Assert.That(_airport.Clients.Count, Is.EqualTo(1));
    }

    [Test]
    public void MergingTwoClientsRemovesTheOtherFromTaskList()
    {
      var clientOne = TaskFactory.Instance.CreatePassengerTask(_airport);
      var clientTwo = TaskFactory.Instance.CreatePassengerTask(_airport);

      _scenario.Tasks.Add(clientOne);
      _scenario.Tasks.Add(clientTwo);

      _airport.AddClient(clientOne);
      _airport.AddClient(clientTwo);

      Assert.That(_scenario.Tasks.Count, Is.EqualTo(1));
    }

    [Test]
    public void HandlingFightRemovesOneTick()
    {
      var fight = TaskFactory.Instance.CreateFightTask();
      _scenario.Tasks.Add(fight);

      var initial = fight.Health;
      fight.HandleEvent();
      var after = fight.Health;

      Assert.That(after, Is.EqualTo(initial - 1));
    }

    [Test]
    public void HandlingEventRemovesFromList()
    {
      var scout = TaskFactory.Instance.CreateScoutTask();
      _scenario.Tasks.Add(scout);

      scout.HandleEvent();

      Assert.That(_scenario.Tasks.Count, Is.EqualTo(0));
    }
  }
}