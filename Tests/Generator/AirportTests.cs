using System.Collections.Generic;
using Generator.Models;
using NUnit.Framework;

namespace Tests.Generator
{
  [TestFixture]
  public class AirportTests
  {
    private Airport _airport;
    private Dictionary<string, object> _baseDetails;
    private Dictionary<string, object> _detailsWithoutType;

    [SetUp]
    public void Setup()
    {
      _airport = new Airport("CRS", "Coruscant", new Position(0, 0), 100, 100);
      _baseDetails = new Dictionary<string, object>
      {
        {"id", "T-01"},
        {"name", "Tie Fighter"},
        {"type", AirplaneType.Fight},
        {"speed", 100},
        {"maintenanceTime", 2}
      };
      _detailsWithoutType = new Dictionary<string, object>
      {
        {"id", "T-01"},
        {"name", "Tie Fighter"},
        {"speed", 100},
        {"maintenanceTime", 2}
      };
    }

    [Test]
    [TestCase(AirplaneType.Cargo)]
    [TestCase(AirplaneType.Fight)]
    [TestCase(AirplaneType.Passenger)]
    [TestCase(AirplaneType.Scout)]
    [TestCase(AirplaneType.Rescue)]
    public void AddingANewPlane(AirplaneType type)
    {
      _detailsWithoutType.Add("type", type);
      _airport.AddAirplane(_detailsWithoutType);

      Assert.That(_airport.HasPlane("T-01"), Is.True);
    }

    [Test]
    public void EditingPlane()
    {
      _airport.AddAirplane(_baseDetails);
      var newPlaneDetails = new Dictionary<string, object>
      {
        {"id", "X-01"},
        {"name", "X-Wing"},
        {"type", AirplaneType.Fight},
        {"speed", 200},
        {"maintenanceTime", 3}
      };
      _airport.EditAirplane("T-01", newPlaneDetails);
      Assert.That(_airport.HasPlane("X-01"), Is.True);
    }

    [Test]
    public void RemovingPlane()
    {
      _airport.AddAirplane(_baseDetails);
      _airport.DeleteAirplane("T-01");
      
      Assert.That(_airport.HasPlane("T-01"), Is.False);
    }

    [Test]
    public void FindPlane()
    {
      var plane = new FightPlane("T-01", "Tie Fighter", 100, 2);
      _airport.Airplanes.Add(plane);
      
      Assert.That(_airport.HasPlane("T-01"), Is.True);
    }
    
    [Test]
    public void FindingANonExistingPlane()
    {
      Assert.That(_airport.HasPlane("T-01"), Is.False);
    }

    [Test]
    public void IncompleteInfo()
    {
      var incompleteInfo = new Dictionary<string, object>
      {
        {"id", "T-01"},
        {"name", "Tie Fighter"},
        {"type", AirplaneType.Fight},
        {"speed", 100}
      };
      
      // This should throw an exception, since we do not have the base plane details
      Assert.That(() => _airport.AddAirplane(incompleteInfo), Throws.ArgumentException);
    }

    [Test]
    public void EditingNonExistingPlane()
    {
      Assert.That(() => _airport.EditAirplane("T-01", _baseDetails), Throws.Nothing);
    }

    [Test]
    public void RemovingNonExistingPlane()
    {
      Assert.That(() => _airport.DeleteAirplane("X-01"), Throws.Nothing);
    }
  }
}