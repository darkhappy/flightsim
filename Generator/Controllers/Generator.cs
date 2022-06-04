using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Generator.Models;

namespace Generator.Controllers
{
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

    private void GenerateView()
    {
      _frmGen.UpdateAirports(_scenario.GetAirportsInfo());
      Application.Run(_frmGen);
    }

    public void UpdateAirplanes(string id)
    {
      _frmGen.UpdateAirplanes(_scenario.GetAirplanesInfo(id));
    }

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

    public void Export(string path)
    {
      var serializer = new DataContractSerializer(typeof(Scenario));
      using var stream = new FileStream(path, FileMode.Create);
      try
      {
        serializer.WriteObject(stream, _scenario);
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
      finally
      {
        stream.Close();
      }
    }

    public void Import(string path)
    {
      var serializer = new DataContractSerializer(typeof(Scenario));
      using var stream = new FileStream(path, FileMode.Open);
      try
      {
        _scenario = (Scenario) serializer.ReadObject(stream);
      }
      catch (Exception e)
      {
        MessageBox.Show(e.Message);
      }
      finally
      {
        stream.Close();
      }

      var airportInfo = _scenario.GetAirportsInfo();

      _frmGen.UpdateAirports(airportInfo);
    }
  }
}