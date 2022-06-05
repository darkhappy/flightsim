using System.IO;
using System.Runtime.Serialization;
using NUnit.Framework;
using Simulator.Models;
using Simulator.Models.States;

namespace Tests.Simulator
{
  [TestFixture]
  public class ScenarioTests
  {
    [SetUp]
    public void SetUp()
    {
      _scenario = new Scenario();
    }

    private Scenario _scenario;

    [Test]
    public void ImportAddsAllAirports()
    {
      var reader = new FileStream("test.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario = (Scenario) serializer.ReadObject(reader);

      reader.Close();

      Assert.That(_scenario.Airports.Count, Is.EqualTo(2));
    }

    [Test]
    public void ImportAddsAllAirplanesToAirport()
    {
      var reader = new FileStream("test.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario = (Scenario) serializer.ReadObject(reader);

      reader.Close();

      Assert.That(_scenario.Airports[0].Airplanes.Count, Is.EqualTo(2));
    }

    [Test]
    public void ImportSetsAirplaneOrigin()
    {
      var reader = new FileStream("test.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario = (Scenario) serializer.ReadObject(reader);

      reader.Close();

      Assert.That(_scenario.Airports[0].Airplanes[0].Origin, Is.EqualTo(_scenario.Airports[0]));
    }

    [Test]
    public void ImportSetsAirplaneState()
    {
      var reader = new FileStream("test.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario = (Scenario) serializer.ReadObject(reader);

      reader.Close();

      Assert.That(_scenario.Airports[0].Airplanes[0].State, Is.TypeOf<StandbyState>());
    }

    [Test]
    public void ImportInitializesTasksList()
    {
      var reader = new FileStream("test.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario = (Scenario) serializer.ReadObject(reader);

      reader.Close();

      Assert.That(_scenario.Tasks.Count, Is.EqualTo(0));
    }

    [Test]
    public void ImportInitializesUnassignedTasksList()
    {
      var reader = new FileStream("test.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario = (Scenario) serializer.ReadObject(reader);

      reader.Close();

      Assert.That(_scenario.UnassignedTasks.Count, Is.EqualTo(0));
    }

    [Test]
    public void CannotImportAScenarioWithOnlyOneAirport()
    {
      var reader = new FileStream("oneairport.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      void Read()
      {
        _scenario = (Scenario) serializer.ReadObject(reader);
      }

      Assert.That(Read, Throws.Exception);

      reader.Close();
    }

    [Test]
    [TestCase(100, 100, "CRS")]
    [TestCase(500, 450, "DS")]
    public void FindNearestAirport(int x, int y, string id)
    {
      var reader = new FileStream("test.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario = (Scenario) serializer.ReadObject(reader);

      reader.Close();

      var position = new Position(x, y);
      var airport = _scenario.GetNearestAirport(position);

      Assert.That(airport.Id, Is.EqualTo(id));
    }
  }
}