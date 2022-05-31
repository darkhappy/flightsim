using System.IO;
using System.Runtime.Serialization;
using NUnit.Framework;
using Simulator.Models;
using Simulator.Models.Airplanes;

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
    public void Export()
    {
      var writer = new FileStream("uwu.xml", FileMode.Create);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario.Airports.Add(new Airport("CRS", "Coruscant", new Position(0, 0), 4, 4));

      serializer.WriteObject(writer, _scenario);

      writer.Close();
    }

    [Test]
    public void Import()
    {
      var reader = new FileStream("test.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario = (Scenario) serializer.ReadObject(reader);

      reader.Close();

      Assert.That(_scenario.Airports.Count, Is.EqualTo(2));
    }
  }
}