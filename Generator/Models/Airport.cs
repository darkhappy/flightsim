using System;
using System.Collections.Generic;
using System.Linq;

namespace Generator.Models
{
  public class Airport
  {
    public Airport(string id, string name, Position position, int passengerTraffic, double cargoTraffic)
    {
      Id = id;
      Name = name;
      Position = position;
      Airplanes = new List<Airplane>();
      PassengerTraffic = passengerTraffic;
      CargoTraffic = cargoTraffic;
    }
    
    public Airplane? FindAirplane(string id)
    {
      return Airplanes.FirstOrDefault(a => a.Id == id);
    }

    public string Id { get; set; }
    public string Name { get; set; }
    public Position Position { get; set; }
    public int PassengerTraffic { get; set; }
    public double CargoTraffic { get; set; }
    public List<Airplane> Airplanes { get; }

    public void Action(double time)
    {
      throw new NotImplementedException();
    }

    public bool HasPlane(string airplaneCode)
    {
      return Airplanes.Any(a => a.Id == airplaneCode);
    }
    
    public void AddAirplane(string[] data)
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

  }
}