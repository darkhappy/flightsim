using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Generator.Models
{
  public class Scenario : IExtensibleDataObject
  {
    public Scenario()
    {
      Airports = new List<Airport>();
    }

    [DataMember] public List<Airport> Airports { get; }

    public ExtensionDataObject ExtensionData { get; set; } = null!;

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
      if (HasAirplane(info.Id)) throw new ArgumentException($"Airplane {id} already exists.");

      var airport = GetAirport(id);
      if (airport == null) throw new ArgumentException($"Airport {id} was not found.");

      airport.AddAirplane(info);
    }

    public void EditAirplane(string id, AirplaneInfo info)
    {
      var airport = GetAirportWithPlane(id);
      if (airport == null) throw new ArgumentException($"Airplane {id} was not found.");

      airport.EditAirplane(id, info);
    }

    public void DeleteAirplane(string id)
    {
      var airport = GetAirportWithPlane(id);
      if (airport == null) throw new ArgumentException($"Airplane {id} was not found.");

      airport.DeleteAirplane(id);
    }

    public void AddAirport(AirportInfo info)
    {
      if (HasAirport(info.Id)) throw new ArgumentException($"Airport {info.Id} already exists.");

      var newAirport = new Airport(info);
      Airports.Add(newAirport);
    }

    public void EditAirport(string id, AirportInfo info)
    {
      var airport = GetAirport(id);
      if (airport == null) throw new ArgumentException($"Airport {id} was not found.");

      airport.Id = info.Id;
      airport.Name = info.Name;
      airport.Position = info.Position;
      airport.CargoTraffic = info.CargoTraffic;
      airport.PassengerTraffic = info.PassengerTraffic;
    }

    public void DeleteAirport(string id)
    {
      var airport = GetAirport(id);
      if (airport == null) throw new ArgumentException($"Airport {id} was not found.");

      Airports.Remove(airport);
    }

    public bool HasAirplane(string id)
    {
      return GetAirportWithPlane(id) != null;
    }

    public List<AirportInfo> GetAirportsInfo()
    {
      return Airports.Select(a => a.ToAirportInfo()).ToList();
    }

    public List<AirplaneInfo> GetAirplanesInfo(string id)
    {
      var airport = GetAirport(id);
      if (airport == null) throw new ArgumentException($"Airport {id} was not found.");

      return airport.GetAirplanesInfo();
    }
  }
}