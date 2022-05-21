using System.Collections.Generic;
using System.Linq;

namespace Generator.Models
{
  public class Scenario
  {
    public Scenario()
    {
      Airports = new List<Airport>();
    }

    public List<Airport> Airports { get; }

    private Airport? GetAirportWithPlane(string airplaneCode)
    {
      return Airports.FirstOrDefault(a => a.HasPlane(airplaneCode));
    }

    private Airport? GetAirport(string airportCode)
    {
      return Airports.FirstOrDefault(a => a.Id == airportCode);
    }

    public bool HasAirport(string airportCode)
    {
      return GetAirport(airportCode) != null;
    }

    public void AddAirplane(string id, AirplaneInfo info)
    {
      if (HasAirplane(info.Id)) return;

      var airport = GetAirport(id);

      airport?.AddAirplane(info);
    }

    public void EditAirplane(string id, AirplaneInfo info)
    {
      var airport = GetAirportWithPlane(id);

      airport?.EditAirplane(id, info);
    }

    public void DeleteAirplane(string id)
    {
      var airport = GetAirportWithPlane(id);

      airport?.DeleteAirplane(id);
    }

    public void AddAirport(AirportInfo info)
    {
      if (HasAirport(info.Id)) return;

      var newAirport = new Airport(info);
      Airports.Add(newAirport);
    }

    public void EditAirport(string id, AirportInfo info)
    {
      var airport = GetAirport(id);
      if (airport == null) return;

      airport.Id = info.Id;
      airport.Name = info.Name;
      airport.Position = info.Position;
      airport.CargoTraffic = info.CargoTraffic;
      airport.PassengerTraffic = info.PassengerTraffic;
    }

    public void DeleteAirport(string id)
    {
      var airport = GetAirport(id);
      if (airport == null) return;

      Airports.Remove(airport);
    }

    public void Export()
    {
    }

    public bool HasAirplane(string id)
    {
      return GetAirportWithPlane(id) != null;
    }
  }
}