using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Generator.Models
{
  [DataContract(Namespace = "")]
  public class Airport : IExtensibleDataObject
  {
    public Airport(AirportInfo data)
    {
      Id = data.Id;
      Name = data.Name;
      Position = data.Position;
      Airplanes = new List<Airplane>();
      PassengerTraffic = data.PassengerTraffic;
      CargoTraffic = data.CargoTraffic;
    }

    [DataMember] public string Id { get; set; }

    [DataMember] public string Name { get; set; }

    [DataMember] public Position Position { get; set; }

    [DataMember] public int PassengerTraffic { get; set; }

    [DataMember] public double CargoTraffic { get; set; }

    [DataMember] public List<Airplane> Airplanes { get; private set; }

    public ExtensionDataObject ExtensionData { get; set; } = null!;

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

      // If the airplane is not found, throw an exception
      if (oldPlane == null) throw new ArgumentException($"Airplane {id} was not found.");

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
      if (oldPlane == null) throw new ArgumentException($"Airplane {id} was not found.");

      Airplanes.Remove(oldPlane);
    }

    public List<AirplaneInfo> GetAirplanesInfo()
    {
      return Airplanes.Select(airplane => airplane.ToAirplaneInfo()).ToList();
    }

    public AirportInfo ToAirportInfo()
    {
      return new AirportInfo(Id, Name, Position, PassengerTraffic, CargoTraffic);
    }
  }
}