using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using Generator.Models;
using NUnit.Framework;
using Simulator.Controllers;

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

      var newAirplane = new TransportInfo("X-01", "Tie Fighter", AirplaneType.Cargo, 60, 420, 420, 2, 2);
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

    [Test]
    public void Serializer()
    {
      _scenario.AddAirport(_airportInfo);

      var airplane = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", airplane);

      var newAirplane = new AirplaneInfo("X-01", "X-Wing", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("CRS", newAirplane);

      var airport2 = new AirportInfo("DS", "Death Star", new Position(400, 400), 241, 1515);
      _scenario.AddAirport(airport2);
      var airplane4 = new AirplaneInfo("T-02", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("DS", airplane4);
      var airplane5 = new AirplaneInfo("T-03", "Tie Fighter", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("DS", airplane5);
      var newairplane2 = new AirplaneInfo("X-02", "X-Wing", AirplaneType.Fight, 420, 60);
      _scenario.AddAirplane("DS", newairplane2);

      var transpo = new TransportInfo("uwu", "Uwu Shuttle", AirplaneType.Passenger, 420, 420, 420, 420, 420);
      _scenario.AddAirplane("DS", transpo);

      var writer = new FileStream("test.xml", FileMode.Create);
      var serializer = new DataContractSerializer(typeof(Scenario));

      Assert.That(() => serializer.WriteObject(writer, _scenario), Throws.Nothing);

      writer.Close();
    }

    [Test]
    public void Deserializer()
    {
      Serializer();

      var reader = new FileStream("test.xml", FileMode.Open);
      var serializer = new DataContractSerializer(typeof(Scenario));

      _scenario = (Scenario) serializer.ReadObject(reader);

      Assert.That(_scenario.Airports.Count, Is.EqualTo(2));

      reader.Close();
    }


    private string RandomName()
    {
      var list = new List<string>
      {
        "X-Wing",
        "Y-Wing",
        "A-Wing",
        "B-Wing",
        "TIE Fighter",
        "TIE Interceptor",
        "TIE Bomber",
        "TIE Advanced",
        "TIE Defender",
        "TIE Phantom",
        "TIE Silencer",
        "TIE Defender",
        "Imperial Starfighter",
        "TIE/SF Fighter",
        "TIE/IN Interceptor",
        "TIE/LN Bomber",
        "TIE/VN Silencer",
        "TIE/VN Phantom",
        "TIE/VN Defender",
        "Imperial Shuttle",
        "Imperial Star Destroyer"
      };

      return list[new Random().Next(0, list.Count)];
    }

    private string RandomCodename()
    {
      // Create codenames for ships
      // They just need to be very cool and unique
      // A codename is "the <blank>", or "the <blank> of <blank>"
      var list = new List<string>
      {
        "the Menace",
        "the Destroyer",
        "the Nemesis",
        "the Predator",
        "the Agile",
        "the Swift",
        "the Silent",
        "the Silent One",
        "the Rogue",
        "the Ghost",
        "the Giant",
        "the Avenger",
        "the Invincible",
        "the Mighty",
        "the Mighty One",
        "the Brave",
        "the Bandit",
        "the Pirate",
        "the Corsair",
        "the Crusader",
        "the Dark",
        "the Dread"
      };

      return list[new Random().Next(0, list.Count)];
    }

    private List<string> RandomAirportName()
    {
      // Create names for airports
      // They are star wars locations
      // Starbases are also allowed (such as the death star)
      // Duplicate names are not allowed
      return new List<string>
      {
        "Alderaan",
        "Bespin",
        "Coruscant",
        "Dagobah",
        "Endor",
        "Geonosis",
        "Hoth",
        "Kamino",
        "Kashyyyk",
        "Mustafar",
        "Naboo",
        "Polis Massa",
        "Ryloth",
        "Tatooine",
        "Yavin IV"
      };
    }

    private AirplaneType RandomShipType()
    {
      var list = new List<AirplaneType>
      {
        AirplaneType.Fight,
        AirplaneType.Rescue,
        AirplaneType.Scout
      };

      return list[new Random().Next(0, list.Count)];
    }

    private AirplaneType RandomCargoType()
    {
      var list = new List<AirplaneType>
      {
        AirplaneType.Cargo,
        AirplaneType.Passenger
      };

      return list[new Random().Next(0, list.Count)];
    }

    [Test]
    public void GenerateAnExtremelyBigButRandomScenario()
    {
      var airportList = RandomAirportName();
      // For each airport, create a random number of ships
      // Ship ID must be unique
      // Ship name is from RandomName + RandomCodename

      foreach (var airport in airportList)
      {
        // ID of an airport is the first three letters
        // of the airport name, in all caps
        var id = airport.Substring(0, 3).ToUpper();
        var randomX = new Random().Next(Constants.MapWidth);
        var randomY = new Random().Next(Constants.MapHeight);
        var randomPassengerTraffic = new Random().Next(Constants.MaxPassengersPerHour);
        var randomCargoTraffic = new Random().Next(Constants.MaxCargoPerHour);
        var info = new AirportInfo(id, airport, new Position(randomX, randomY), randomPassengerTraffic,
          randomCargoTraffic);

        var randomAirplaneCount = new Random().Next(40, 60);
        var randomTransportCount = new Random().Next(20, 30);

        _scenario.AddAirport(info);

        for (var i = 0; i < randomAirplaneCount; i++)
        {
          var randomName = RandomName();
          var randomCodename = RandomCodename();
          var randomShipId = $"{id}-{i}";
          var randomShipName = $"{randomName} {randomCodename}";

          var type = RandomShipType();
          var randomSpeed = new Random().Next(10, 50);
          var randomMaintenance = new Random().Next(4, 20);

          var randomShip = new AirplaneInfo(randomShipId, randomShipName, type, randomSpeed, randomMaintenance);
          _scenario.AddAirplane(id, randomShip);
        }

        for (var i = 0; i < randomTransportCount; i++)
        {
          var randomName = RandomName();
          var randomCodename = RandomCodename();
          var randomShipId = $"{id}-T{i}";
          var randomShipName = $"{randomName} {randomCodename}";

          var type = RandomCargoType();
          var randomSpeed = new Random().Next(10, 50);
          var randomMaintenance = new Random().Next(4, 20);
          var randomCapacity = new Random().NextDouble() * 100 + 20;
          var randomEmbarkingTime = new Random().Next(1, 10);
          var randomDisembarkingTime = new Random().Next(1, 10);

          var randomShip = new TransportInfo(randomShipId, randomShipName, type, randomSpeed, randomMaintenance,
            randomCapacity, randomEmbarkingTime, randomDisembarkingTime);
          _scenario.AddAirplane(id, randomShip);
        }
      }

      // Serialize
      var writer = new FileStream("verybig.xml", FileMode.Create);
      var serializer = new DataContractSerializer(typeof(Scenario));

      serializer.WriteObject(writer, _scenario);
      writer.Close();
    }
  }
}