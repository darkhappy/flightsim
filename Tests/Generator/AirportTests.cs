using Generator.Models;
using NUnit.Framework;

namespace Tests.Generator
{
  [TestFixture]
  public class AirportTests
  {
    [SetUp]
    public void Setup()
    {
      _airport = new Airport(new AirportInfo("CRS", "Coruscant", new Position(0, 0), 100, 100));
      _baseDetails = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Fight, 4, 4);
      _baseTransportDetails = new TransportInfo("T-01", "Tie Fighter", AirplaneType.Passenger, 4, 4, 420, 60, 30);
    }

    private Airport _airport;
    private AirplaneInfo _baseDetails;
    private TransportInfo _baseTransportDetails;

    [Test]
    [TestCase(AirplaneType.Fight)]
    [TestCase(AirplaneType.Scout)]
    [TestCase(AirplaneType.Rescue)]
    public void AddingANewPlane(AirplaneType type)
    {
      _baseDetails.Type = type;
      _airport.AddAirplane(_baseDetails);

      Assert.That(_airport.HasPlane("T-01"), Is.True);
    }

    [Test]
    [TestCase(AirplaneType.Cargo)]
    [TestCase(AirplaneType.Passenger)]
    public void AddingANewTransportPlane(AirplaneType type)
    {
      _baseTransportDetails.Type = type;
      _airport.AddAirplane(_baseTransportDetails);

      Assert.That(_airport.HasPlane("T-01"), Is.True);
    }

    [Test]
    public void EditingPlane()
    {
      _airport.AddAirplane(_baseDetails);

      var newPlaneDetails = _baseDetails;
      newPlaneDetails.Id = "X-01";

      _airport.EditAirplane("T-01", newPlaneDetails);
      Assert.That(_airport.HasPlane("X-01"), Is.True);
    }

    [Test]
    public void EditingTransportPlane()
    {
      _airport.AddAirplane(_baseTransportDetails);

      var newPlaneDetails = _baseTransportDetails;
      newPlaneDetails.Id = "X-01";
      newPlaneDetails.DisembarkingTime = 40;
      newPlaneDetails.EmbarkingTime = 40;
      newPlaneDetails.MaxCapacity = 100;

      _airport.EditAirplane("T-01", newPlaneDetails);

      Assert.That(_airport.HasPlane("X-01"), Is.True);
    }

    [Test]
    public void EditingPlaneType()
    {
      _airport.AddAirplane(_baseDetails);

      var newPlaneDetails = new TransportInfo("X-01", "X-Wing", AirplaneType.Passenger, 4, 4, 420, 60, 30);

      _airport.EditAirplane("T-01", newPlaneDetails);

      var newPlane = _airport.FindAirplane("X-01");
      Assert.That(newPlane, Is.TypeOf<PassengerPlane>());
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
      _airport.AddAirplane(_baseDetails);

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
      var incompleteInfo = new AirplaneInfo("T-01", "Tie Fighter", AirplaneType.Cargo, 4, 4);

      // Should throw an error, as there can't be a max capacity of 0.
      Assert.That(() => _airport.AddAirplane(incompleteInfo), Throws.Exception);
    }

    [Test]
    public void EditingNonExistingPlane()
    {
      Assert.That(() => _airport.EditAirplane("T-01", _baseDetails), Throws.ArgumentException);
    }

    [Test]
    public void RemovingNonExistingPlane()
    {
      Assert.That(() => _airport.DeleteAirplane("X-01"), Throws.ArgumentException);
    }
  }
}