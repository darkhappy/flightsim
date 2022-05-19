using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Models
{
  public class Scenario
  {
    private List<Airport> _airports;

    public Scenario()
    {
      _airports = new List<Airport>();
    }

    private Airport? GetAirportWithPlane(string airplaneCode)
    {
      return _airports.FirstOrDefault(a => a.HasPlane(airplaneCode));
    }

    private Airport? GetAirport(string airportCode)
    {
      return _airports.FirstOrDefault(a => a.Id == airportCode);
    }

    public void AddAirplane(string id, string[] data)
    {
      throw new NotImplementedException();
    }

    public void EditAirplane(string id, string[] data)
    {
      throw new NotImplementedException();
    }

    public void DeleteAirplane(string id)
    {
      throw new NotImplementedException();
    }

    public void AddAirport(string[] data)
    {
      throw new NotImplementedException();
    }

    public void EditAirport(string id, string[] data)
    {
      throw new NotImplementedException();
    }

    public void DeleteAirport(string id)
    {
      throw new NotImplementedException();
    }

    public void Export()
    {
    }
  }
}