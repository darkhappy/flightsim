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

    public bool HasPlane(string airplaneCode)
    {
      return Airplanes.Any(a => a.Id == airplaneCode);
    }
    
    public void AddAirplane(Dictionary<string, object> data)
    {
      var newPlane = AirplaneFactory.Instance.CreateAirplane(data);
      Airplanes.Add(newPlane);
    }

    public void EditAirplane(string id, Dictionary<string, object> data)
    {
      // TODO: Probably edit the airplane itself, not create a new one?
      // Get the old airplane
      var oldPlane = FindAirplane(id);
      if (oldPlane == null)
      {
        return;
      }
      
      // Remove the old airplane
      Airplanes.Remove(oldPlane);
      
      // Create the new airplane
      var newPlane = AirplaneFactory.Instance.CreateAirplane(data);
      Airplanes.Add(newPlane);
    }

    public void DeleteAirplane(string id)
    {
      var oldPlane = FindAirplane(id);
      if (oldPlane == null)
      {
        return;
      }
      
      Airplanes.Remove(oldPlane);
    }

  }
}