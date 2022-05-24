using Generator.Models;
using NUnit.Framework;

namespace Tests.Generator
{
  [TestFixture]
  public class ScenarioTests
  {
    [SetUp]
    public void SetUp()
    {
      _airportInfo = new AirportInfo("CRS", "Coruscant", new Position(0, 0), 1000, 1000);
      _scenario = new Scenario();
    }

    private Scenario _scenario;
    private AirportInfo _airportInfo;

    [Test]
    public void AddingANewAirport()
    {
      _scenario.AddAirport(_airportInfo);
      Assert.That(_scenario.Airports.Count, Is.EqualTo(1));
    }

    [Test]
    public void EditingAnAirport()
    {
      _scenario.AddAirport(_airportInfo);

      var newAirportInfo = new AirportInfo("DS-01", "Death Star", new Position(40, 40), 1000, 1000);

      _scenario.EditAirport("CRS", newAirportInfo);
      Assert.That(_scenario.HasAirport("DS-01"), Is.True);
    }

    [Test]
    public void RemovingAnAirport()
    {
      _scenario.AddAirport(_airportInfo);
      _scenario.DeleteAirport("CRS");
      Assert.That(_scenario.Airports.Count, Is.EqualTo(0));
    }

    [Test]
    public void AddingAPlane()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      Assert.That(_scenario.Airports.Find(a => a.Id == "CRS").HasPlane("T-01"), Is.True);
    }

    [Test]
    public void CheckIfAirplaneExists()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      Assert.That(_scenario.HasAirplane("T-01"), Is.True);
    }

    [Test]
    public void EditingAnAirplane()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      var newAirplane = new AirplaneInfo("X-01", "X-Wing", AirplaneType.Fight, 420, 60);
      _scenario.EditAirplane("T-01", newAirplane);

      Assert.That(_scenario.HasAirplane("X-01"), Is.True);
    }

    [Test]
    public void EditingAnAirplaneId()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      var newAirplane = new AirplaneInfo("X-01", "X-Wing", AirplaneType.Fight, 420, 60);
      _scenario.EditAirplane("T-01", newAirplane);

      Assert.That(_scenario.HasAirplane("T-01"), Is.False);
    }

    [Test]
    public void DeletingAnAirplane()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);
      _scenario.DeleteAirplane("T-01");

      Assert.That(_scenario.HasAirplane("T-01"), Is.False);
    }

    [Test]
    public void DeletingANonExistentAirplane()
    {
      _scenario.AddAirport(_airportInfo);

      void Delete()
      {
        _scenario.DeleteAirplane("T-01");
      }


      Assert.That(Delete, Throws.ArgumentException);
    }

    [Test]
    public void CheckIfAirplaneDoesNotExist()
    {
      _scenario.AddAirport(_airportInfo);
      Assert.That(_scenario.HasAirplane("T-01"), Is.False);
    }

    [Test]
    public void CannotAddDuplicatePlaneToSameAirport()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      void AddDuplicatePlane()
      {
        _scenario.AddAirplane("CRS", airplane);
      }

      Assert.That(AddDuplicatePlane, Throws.ArgumentException);
    }

    [Test]
    public void CannotAddDuplicatePlaneToDifferentAirport()
    {
      // Add two airports, CRS and DS-01
      _scenario.AddAirport(_airportInfo);
      _airportInfo.Id = "DS-01";
      _scenario.AddAirport(_airportInfo);

      // Try to add T-01 to both airports
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      void AddDuplicatePlane()
      {
        _scenario.AddAirplane("DS-01", airplane);
      }

      // Assert that there is only airplane
      Assert.That(AddDuplicatePlane, Throws.ArgumentException);
    }

    [Test]
    public void CannotAddDuplicateAirport()
    {
      _scenario.AddAirport(_airportInfo);

      void AddDuplicateAirport()
      {
        _scenario.AddAirport(_airportInfo);
      }

      Assert.That(AddDuplicateAirport, Throws.ArgumentException);
    }

    [Test]
    public void CannotEditANonExistentPlane()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      void EditNonExistentPlane()
      {
        _scenario.EditAirplane("T-02", airplane);
      }

      Assert.That(EditNonExistentPlane, Throws.ArgumentException);
    }

    [Test]
    public void AddingToANonExistentAirport()
    {
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);

      void AddAirplane()
      {
        _scenario.AddAirplane("CRS", airplane);
      }

      Assert.That(AddAirplane, Throws.ArgumentException);
    }

    [Test]
    public void EditingNonExistentAirport()
    {
      void EditAirport()
      {
        _scenario.EditAirport("DS-01", _airportInfo);
      }

      Assert.That(EditAirport, Throws.ArgumentException);
    }

    [Test]
    public void DeletingNonExistentAirport()
    {
      void DeleteAirport()
      {
        _scenario.DeleteAirport("DS-01");
      }

      Assert.That(DeleteAirport, Throws.ArgumentException);
    }

    [Test]
    public void ExportingAirplaneData()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      var exportedData = _scenario.GetAirplanesInfo("CRS");

      Assert.That(exportedData, Contains.Item(airplane));
    }

    [Test]
    public void ExportingAirportData()
    {
      _scenario.AddAirport(_airportInfo);

      var exportedData = _scenario.GetAirportsInfo();

      Assert.That(exportedData, Contains.Item(_airportInfo));
    }

    [Test]
    public void ModifyingTransportPlaneDataGivesCorrectResult()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      var newAirplane = new TransportInfo("X-01", "Tie Fighter", AirplaneType.Cargo, 420, 60, 420, 2, 2);
      _scenario.EditAirplane("T-01", newAirplane);

      var exportedData = _scenario.GetAirplanesInfo("CRS");

      Assert.That(exportedData, Contains.Item(newAirplane));
    }

    [Test]
    public void ModifyingAirplaneDataGivesCorrectResult()
    {
      _scenario.AddAirport(_airportInfo);
      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      var newAirplane = new AirplaneInfo("X-01", "Tie Fighter", AirplaneType.Fight, 69, 222);
      _scenario.EditAirplane("T-01", newAirplane);

      var exportedData = _scenario.GetAirplanesInfo("CRS");

      Assert.That(exportedData, Contains.Item(newAirplane));
    }
  }
}