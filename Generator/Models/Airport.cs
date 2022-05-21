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

    public string Id { get; set; }
    public string Name { get; set; }
    public Position Position { get; set; }
    public int PassengerTraffic { get; set; }
    public double CargoTraffic { get; set; }
    public List<Airplane> Airplanes { get; }

    public Airplane? FindAirplane(string id)
    {
      return Airplanes.FirstOrDefault(a => a.Id == id);
    }

    public bool HasPlane(string airplaneCode)
    {
      return Airplanes.Any(a => a.Id == airplaneCode);
    }

    public void AddAirplane(AirplaneInfo data)
    {
      var newPlane = AirplaneFactory.Instance.CreateAirplane(data);
      Airplanes.Add(newPlane);
    }

    public void EditAirplane(string id, AirplaneInfo data)
    {
      // Get the old airplane
      var oldPlane = FindAirplane(id);

      // If the airplane is not found, return
      if (oldPlane == null) return;

      // If the type of the airplane has changed, remove the old one and add a new one
      if (oldPlane.Type != data.Type)
      {
        DeleteAirplane(id);
        AddAirplane(data);
      }
      else
      {
        // Otherwise, just edit the old one
        oldPlane.Edit(data);
      }
    }

    public void DeleteAirplane(string id)
    {
      var oldPlane = FindAirplane(id);
      if (oldPlane == null) return;

      Airplanes.Remove(oldPlane);
    }
  }
}