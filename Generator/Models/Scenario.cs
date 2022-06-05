using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Generator.Models
{
  /// <summary>
  ///   Class representing the current scenario in the generator.
  /// </summary>
  [DataContract(Namespace = "")]
  public class Scenario : IExtensibleDataObject
  {
    /// <summary>
    ///  Constructor for the <see cref="Scenario" /> class.
    /// </summary>
    public Scenario()
    {
      Airports = new List<Airport>();
    }

    /// <summary>
    ///   Represents all airports in the <see cref="Scenario"/>.   
    /// </summary>
    /// <seealso cref="Airport" />
    [DataMember] public List<Airport> Airports { get; private set; }

    /// <summary>
    ///   Used for serializer
    /// </summary>
    public ExtensionDataObject ExtensionData { get; set; } = null!;

    /// <summary>
    ///   Try to get an <see cref="Airport"/> containing the <see cref="Airplane"/>
    /// </summary>
    /// <param name="airplaneCode"> The unique identifier or the <see cref="Airplane" />.</param>
    /// <returns>The <see cref="Airport"/> or Null if not found </returns>
    public Airport? GetAirportWithPlane(string airplaneCode)
    {
      return Airports.FirstOrDefault(a => a.HasPlane(airplaneCode));
    }

    /// <summary>
    ///   Try to get an <see cref="Airport"/> with its ID
    /// </summary>
    /// <param name="airportCode"> The unique identifier or the <see cref="Airport" />.</param>
    /// <returns>The <see cref="Airport"/> or Null if not found </returns>
    private Airport? GetAirport(string airportCode)
    {
      return Airports.FirstOrDefault(a => a.Id == airportCode);
    }

    /// <summary>
    ///   Check an <see cref="Airport"/> exists by its ID
    /// </summary>
    /// <param name="airportCode"></param>
    /// <returns>Whether an airport has been found</returns>
    public bool HasAirport(string airportCode)
    {
      return GetAirport(airportCode) != null;
    }

    /// <summary>
    ///   Adding a new <see cref="Airplane"/> into the <see cref="Scenario"/> 
    /// </summary>
    /// <param name="airplaineId">The unique identifier or the <see cref="Airplane"/>.</param>
    /// <param name="info">The <see cref="AirplaneInfo"/> of the <see cref="Airplane"/> to add.</param>
    /// <exception cref="ArgumentException">This <see cref="Airplane"/> already exists</exception>
    public void AddAirplane(string airplaineId, AirplaneInfo info)
    {
      if (HasAirplane(info.Id))
        throw new ArgumentException($"Airplane {airplaineId} already exists.");

      var airport = GetAirport(airplaineId);
      if (airport == null) throw new ArgumentException($"Airport {airplaineId} was not found.");

      airport.AddAirplane(info);
    }

    /// <summary>
    ///   Editing an existing <see cref="Airplane"/> from the <see cref="Scenario"/> 
    /// </summary>
    /// <param name="airportId">The unique identifier or the <see cref="Airport"/>.</param>
    /// <param name="info">The <see cref="AirplaneInfo"/> of the edited <see cref="Airplane"/></param>
    /// <exception cref="ArgumentException">No <see cref="Airport"/> with this ID has been found</exception>
    public void EditAirplane(string airportId, AirplaneInfo info)
    {
      var airport = GetAirportWithPlane(airportId);
      if (airport == null) throw new ArgumentException($"Airport {airportId} was not found.");

      airport.EditAirplane(airportId, info);
    }

    /// <summary>
    ///   Deleting an existing <see cref="Airplane"/> from the <see cref="Scenario"/> 
    /// </summary>
    /// <param name="id">The unique identifier or the <see cref="Airplane"/>.</param>
    /// <exception cref="ArgumentException">No <see cref="Airplane"/> with this ID has been found</exception>
    public void DeleteAirplane(string id)
    {
      var airport = GetAirportWithPlane(id);
      if (airport == null) throw new ArgumentException($"Airplane {id} was not found.");

      airport.DeleteAirplane(id);
    }

    /// <summary>
    ///   Adding a new <see cref="Airport"/> into the <see cref="Scenario"/> 
    /// </summary>
    /// <param name="info">The <see cref="AirportInfo"/> of the <see cref="Airport"/> to add.</param>
    /// <exception cref="ArgumentException">This <see cref="Airport"/> already exists</exception>
    public void AddAirport(AirportInfo info)
    {
      if (HasAirport(info.Id)) throw new ArgumentException($"Airport {info.Id} already exists.");

      var newAirport = new Airport(info);
      Airports.Add(newAirport);
    }


    /// <summary>
    ///   Editing an existing <see cref="Airport"/> from the <see cref="Scenario"/> 
    /// </summary>
    /// <param name="airportId">The unique identifier or the <see cref="Airport"/>.</param>
    /// <param name="info">The <see cref="AirportInfo"/> of the edited <see cref="Airport"/></param>
    /// <exception cref="ArgumentException">No <see cref="Airport"/> with this ID has been found</exception>
    public void EditAirport(string airportId, AirportInfo info)
    {
      var airport = GetAirport(airportId);
      if (airport == null) throw new ArgumentException($"Airport {airportId} was not found.");

      airport.Id = info.Id;
      airport.Name = info.Name;
      airport.Position = info.Position;
      airport.CargoTraffic = info.CargoTraffic;
      airport.PassengerTraffic = info.PassengerTraffic;
    }

    /// <summary>
    ///   Deleting an existing <see cref="Airport"/> from the <see cref="Scenario"/> 
    /// </summary>
    /// <param name="id">The unique identifier or the <see cref="Airport"/>.</param>
    /// <exception cref="ArgumentException">No <see cref="Airport"/> with this ID has been found</exception>
    public void DeleteAirport(string id)
    {
      var airport = GetAirport(id);
      if (airport == null) throw new ArgumentException($"Airport {id} was not found.");

      Airports.Remove(airport);
    }

    /// <summary>
    ///   Check if the <see cref="Airplane"/> exists
    /// </summary>
    /// <param name="airplaneId">The unique identifier or the <see cref="Airplane"/></param>
    /// <returns>Whether the <see cref="Airplane"/> exists</returns>
    public bool HasAirplane(string airplaneId)
    {
      return GetAirportWithPlane(airplaneId) != null;
    }

    /// <summary>
    ///   Get all <see cref="AirportInfo"/> of all <see cref="Airport"/> in the <see cref="Scenario"/>
    /// </summary>
    /// <returns>All <see cref="AirportInfo"/> of existing airports</returns>
    public List<AirportInfo> GetAirportsInfo()
    {
      return Airports.Select(a => a.ToAirportInfo()).ToList();
    }

    /// <summary>
    ///   Get all <see cref="AirplaneInfo"/> of all <see cref="Airplane"/> in a spe
    /// </summary>
    /// <param name="airportId">The unique identifier or the <see cref="Airport"/>.</param>
    /// <returns>A list of all <see cref="AirplaneInfo"/></returns>
    /// <exception cref="ArgumentException">No <see cref="Airport"/> with this ID has been found</exception>
    public List<AirplaneInfo> GetAirplanesInfo(string airportId)
    {
      var airport = GetAirport(airportId);
      if (airport == null) throw new ArgumentException($"Airport {airportId} was not found.");

      return airport.GetAirplanesInfo();
    }
  }
}