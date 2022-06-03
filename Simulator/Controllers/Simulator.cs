using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Simulator.Models;
using Simulator.Models.Airplanes;
using Simulator.Views;

namespace Simulator.Controllers

{
  public class Simulator
  {
    private static Simulator _instance;
    private readonly FormSimulator _frmSim;
    private Scenario _scenario;

    /// <summary>
    /// Constructo of a singleton instance of Simulator
    /// </summary>
    private Simulator()
    {
      _frmSim = new FormSimulator();
      //Initialize(_frmSim.Path());
      Application.Run(_frmSim);
    }

    /// <summary>
    /// Checks if there is alredy an existing instance of Simulator, if not, it creates one
    /// </summary>
    public static Simulator Instance => _instance ?? (_instance = new Simulator());

    /// <summary>
    /// Entry point of the Simulator program
    /// </summary>
    /// <param name="args"></param>
    [STAThread]
    public static void Main(string[] args)
    {
      new Simulator();
    }

    /// <summary>
    /// This metyhode intializes the simulation before the first Tick.
    /// It imports the selected scenario and places all elements in the right place
    /// </summary>
    /// <param name="path">
    /// This is the path to the serialized .xml scenario file.
    /// </param>
    public void Initialize(string path)
    {
      Import(path);
      SetAirportPositions();
    }

    /// <summary>
    /// Takes all airports from the scenario airports list and places them on the map.
    /// </summary>
    public void SetAirportPositions()
    {
      foreach (var airport in _scenario.Airports)
      {
        _frmSim.DrawAirport(airport.Position);
        SetAirplanesPositions(airport);
      }
    }

    /// <summary>
    /// If the airplanes are moving on the map, it places them a the right places. 
    /// </summary>
    /// <param name="airport"></param>
    public void SetAirplanesPositions(Airport airport)
    {
      foreach (var airplane in airport.Airplanes)
      {
        //if(airplane.State != StandBy) somthing like that
        //then
        /*
        Position origin = airport.Position;
        Position target = _scenario... pitagore calculations to get angle of image from 90
        */
        double angle = 0;

        _frmSim.DrawAirplane(airplane.Name, airport.Position, angle);
      }
    }

    /// <summary>
    /// It makes alle the actions to be made in a given time from the scenario.
    /// </summary>
    /// <param name="time">
    /// Time given in wich the scenario gets updated
    /// </param>
    public void OnTick(double time)
    {
      /*
      if (CanGenerate())
      {
        //generate new tasks
      }
      */
      UpdateEvents();
      _scenario.HandleTick(time);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    private void UpdateEvents()
    {
      throw new NotImplementedException();
    }

    /// <summary>
    /// Method that takes a .xml file and transforms it into a scenario.
    /// </summary>
    /// <param name="path">
    /// This is the path to the serialized .xml scenario file.
    /// </param>
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
    }
  }
}