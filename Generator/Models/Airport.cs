using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Generator.Models
{
  /// <summary>
  ///   Class representing an airport in the simulation.
  /// </summary>
  [DataContract(Namespace = "")]
  public class Airport : IExtensibleDataObject
  {
    /// <summary>
    ///   Constructor for the <see cref="Airport" /> class.
    /// </summary>
    /// <param name="data"><see cref="AirportInfo"/> of the new <see cref="Airport"/></param>
    public Airport(AirportInfo data)
    {
      Id = data.Id;
      Name = data.Name;
      Position = data.Position;
      Airplanes = new List<Airplane>();
      PassengerTraffic = data.PassengerTraffic;
      CargoTraffic = data.CargoTraffic;
    }

    /// <summary>
    ///   Represents the unique identifier for the <see cref="Airport" />.
    /// </summary>
    [DataMember] public string Id { get; set; }

    /// <summary>
    ///   Represents the name for the <see cref="Airport" />.
    /// </summary>
    [DataMember] public string Name { get; set; }

    /// <summary>
    ///   Represents the <see cref="Position"/> for the <see cref="Airport" />.
    /// </summary>
    [DataMember] public Position Position { get; set; }

    /// <summary>
    ///   Represents the passenger traffic for the <see cref="Airport" />.
    /// </summary>
    [DataMember] public int PassengerTraffic { get; set; }

    /// <summary>
    ///   Represents the cargo traffic for the <see cref="Airport" />.
    /// </summary>
    [DataMember] public double CargoTraffic { get; set; }

    /// <summary>
    ///   Represents all <see cref="Airplane"/> in the <see cref="Airport" />.
    /// </summary>
    [DataMember] public List<Airplane> Airplanes { get; private set; }

    /// <summary>
    ///   Usefull for serialization
    /// </summary>
    public ExtensionDataObject ExtensionData { get; set; } = null!;

    /// <summary>
    ///   Get an <see cref="Airplane"/> from the <see cref="Airport"/> by its ID
    /// </summary>
    /// <param name="id">The unique identifier for the <see cref="Airplane" />.</param>
    /// <returns>An <see cref="Airplane"/> or Null if doesn't exists</returns>
    public Airplane? FindAirplane(string id)
    {
      return Airplanes.FirstOrDefault(a => a.Id == id);
    }

    /// <summary>
    /// Check if the <see cref="Airport"/> contains a <see cref="Airplane"/> by its ID
    /// </summary>
    /// <param name="airplaneCode">The unique identifier for the <see cref="Airplane" /></param>
    /// <returns>Whether the <see cref="Airport"/> contains the <see cref="Airplane"/></returns>
    public bool HasPlane(string airplaneCode)
    {
      return Airplanes.Any(a => a.Id == airplaneCode);
    }

    /// <summary>
    ///   Add a new <see cref="Airplane"/> in the <see cref="Airport"/>  
    /// </summary>
    /// <param name="data"><see cref="AirplaneInfo"/> of the new <see cref="Airplane"/></param>
    public void AddAirplane(AirplaneInfo data)
    {
      var newPlane = AirplaneFactory.Instance.CreateAirplane(data);
      Airplanes.Add(newPlane);
    }

    /// <summary>
    ///   Edit an <see cref="Airplane"/> in the <see cref="Airport"/>
    /// </summary>
    /// <param name="id">The unique identifier for the <see cref="Airplane" /></param>
    /// <param name="data">New value of the <see cref="Airplane"/></param>
    /// <exception cref="ArgumentException">The <see cref="Airplane"/> has not been found</exception>
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

    /// <summary>
    ///   Delete an <see cref="Airplane"/> in the <see cref="Airport"/>
    /// </summary>
    /// <param name="id">The unique identifier for the <see cref="Airplane" /></param>
    /// <exception cref="ArgumentException">The <see cref="Airplane"/> has not been found</exception>
    public void DeleteAirplane(string id)
    {
      var oldPlane = FindAirplane(id);
      if (oldPlane == null) throw new ArgumentException($"Airplane {id} was not found.");

      Airplanes.Remove(oldPlane);
    }

    /// <summary>
    ///   Get all <see cref="AirplaneInfo"/> in the <see cref="Airport"/>
    /// </summary>
    /// <returns>All <see cref="AirplaneInfo"/> in the <see cref="Airport"/></returns>
    public List<AirplaneInfo> GetAirplanesInfo()
    {
      return Airplanes.Select(airplane => airplane.ToAirplaneInfo()).ToList();
    }

    /// <summary>
    ///   Get <see cref="AirportInfo"/> from the <see cref="Airport"/>
    /// </summary>
    /// <returns><see cref="AirportInfo"/> of the <see cref="Airport"/></returns>
    public AirportInfo ToAirportInfo()
    {
      return new AirportInfo(Id, Name, Position, PassengerTraffic, CargoTraffic);
    }
  }
}