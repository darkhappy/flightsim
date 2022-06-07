using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Generator.Models;

namespace Generator.Controllers
{
  /// <summary>
  ///   Class representing the generator.
  /// </summary>
  public class Generator
  {
    public const int MapHeight = 650;
    public const int MapWidth = 1500;
    private static Generator _instance;
    private readonly FormGenerator _frmGen;
    private Scenario _scenario;

    /// <summary>
    ///   Constructor of <see cref="Generator" />
    /// </summary>
    private Generator()
    {
      _scenario = new Scenario();
      _frmGen = new FormGenerator();
    }

    /// <summary>
    ///   Singleton getter of <see cref="Generator" />
    /// </summary>
    public static Generator Instance => _instance ??= new Generator();

    /// <summary>
    ///   Entry point of the application
    /// </summary>
    /// <param name="args"></param>
    [STAThread]
    public static void Main(string[] args)
    {
      Instance.GenerateView();
    }

    /// <summary>
    ///   Generate the <see cref="FormGenerator"/>
    /// </summary>
    private void GenerateView()
    {
      _frmGen.UpdateAirports(_scenario.GetAirportsInfo());
      Application.Run(_frmGen);
    }

    /// <summary>
    /// Shows in the <see cref="FormGenerator"/> all the <see cref="Airplane"/> in the selected <see cref="Airport"/>
    /// </summary>
    /// <param name="id">The unique identifier for the <see cref="Airplane" />.</param>
    public void UpdateAirplanes(string id)
    {
      _frmGen.UpdateAirplanes(_scenario.GetAirplanesInfo(id));
    }

    /// <summary>
    ///   Add an <see cref="Airplane"/> into the <see cref="Scenario"/>
    /// </summary>
    /// <param name="Airportid">The unique identifier for the <see cref="Airport"/> in wich the <see cref="Airplane"/> will be created</param>
    /// <param name="info"><see cref="AirplaneInfo"/> of the new <see cref="Airplane"/> </param>
    public void AddAirplane(string Airportid, AirplaneInfo info)
    {
      try
      {
        _scenario.AddAirplane(Airportid, info);
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
      finally
      {
        UpdateAirplanes(Airportid);
      }
    }

    /// <summary>
    ///    Edit an existing <see cref="Airplane"/> in the <see cref="Scenario"/>
    /// </summary>
    /// <param name="airportId">The <see cref="Airport"/> ID in wich the <see cref="Airplane"/> is edited </param>
    /// <param name="airplaneId">The edited <see cref="Airplane"/> ID</param>
    /// <param name="info">New <see cref="AirplaneInfo"/> of the <see cref="Airplane"/></param>
    public void EditAirplane(string airportId, string airplaneId, AirplaneInfo info)
    {
      try
      {
        _scenario.EditAirplane(airplaneId, info);
      }
      catch (ArgumentException e)
      {
        MessageBox.Show(e.Message);
      }
      finally
      {
        UpdateAirplanes(airportId);
      }
    }

    /// <summary>
    ///   Delete an existing <see cref="Airplane"/> in the <see cref="Scenario"/>
    /// </summary>
    /// <param name="id">The ID of the <see cref="Airplane"/> that will be deleted </param>
    public void DeleteAirplane(string id)
    {
      try
      {
        _scenario.DeleteAirplane(id);
      }
      catch (ArgumentException e)
      {
        MessageBox.Show(e.Message);
      }
    }

    /// <summary>
    ///   Call the <see cref="Scenario" /> to create a new <see cref="Airplane" /> and update the <see cref="FormGenerator" />
    /// </summary>
    /// <param name="info"><see cref="AirplaneInfo" /> to create the new <see cref="Airplane" /></param>
    public void AddAirport(AirportInfo info)
    {
      try
      {
        _scenario.AddAirport(info);
      }
      catch (ArgumentException e)
      {
        MessageBox.Show(e.Message);
      }
      finally
      {
        _frmGen.UpdateAirports(_scenario.GetAirportsInfo());
      }
    }

    /// <summary>
    ///    Edit an existing <see cref="Airport"/> in the <see cref="Scenario"/>
    /// </summary>
    /// <param name="id">The edited <see cref="Airport"/> ID></param>
    /// <param name="info">New <see cref="AirportInfo"/> of the <see cref="Airport"/></param>
    public void EditAirport(string id, AirportInfo info)
    {
      try
      {
        _scenario.EditAirport(id, info);
      }
      catch (ArgumentException e)
      {
        MessageBox.Show(e.Message);
      }
      finally
      {
        _frmGen.UpdateAirports(_scenario.GetAirportsInfo());
      }
    }

    /// <summary>
    ///   Delete an existint <see cref="Airport"/> in the <see cref="Scenario"/>
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Airport"/> that will be deleted</param>
    public void DeleteAirport(string id)
    {
      try
      {
        _scenario.DeleteAirport(id);
      }
      catch (ArgumentException e)
      {
        MessageBox.Show(e.Message);
      }
      finally
      {
        _frmGen.UpdateAirports(_scenario.GetAirportsInfo());
      }
    }

    /// <summary>
    ///   Check if the <see cref="Scenario"/> can be serialized
    /// </summary>
    /// <returns>Whether the <see cref="Scenario"/> can be serialized</returns>
    public bool CanSerialize()
    {
      return _scenario.Airports.Count > 1 ? true : false;
    }

    /// <summary>
    ///   Serialized the <see cref="Scenario"/> in XML 
    /// </summary>
    /// <param name="path">Path of the serialized <see cref="Scenario"/></param>
    public void Export(string path)
    {
      var serializer = new DataContractSerializer(typeof(Scenario));
      using var stream = new FileStream(path, FileMode.Create);
      try
      {
        serializer.WriteObject(stream, _scenario);
        _frmGen.SetPath(path);
        _frmGen.EnableGroups(true);
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
        _frmGen.ResetPath();
        _frmGen.EnableGroups(false);
      }
      finally
      {
        stream.Close();
      }
    }

    /// <summary>
    ///   Import a serialized <see cref="Scenario"/> in its XML form
    /// </summary>
    /// <param name="path">The path of the XML <see cref="Scenario"/></param>
    public void Import(string path)
    {
      var serializer = new DataContractSerializer(typeof(Scenario));
      using var stream = new FileStream(path, FileMode.Open);
      try
      {
        _scenario = (Scenario) serializer.ReadObject(stream);
        _frmGen.SetPath(path);
        _frmGen.EnableGroups(true);
        var airportInfo = _scenario.GetAirportsInfo();
        _frmGen.UpdateAirports(airportInfo);
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
        _frmGen.ResetPath();
        _frmGen.EnableGroups(false);
      }
      finally
      {
        stream.Close();
      }
    }

    /// <summary>
    ///   Gets an airport's position.
    /// </summary>
    /// <param name="text">The airport's ID.</param>
    /// <returns></returns>
    public Position GetAirportPosition(string text)
    {
      return _scenario.GetAirportsInfo().Find(info => info.Id == text).Position;
    }
  }
}