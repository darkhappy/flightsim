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
    private Simulator()
    {
      _frmSim = new FormSimulator();
      Initialize(_frmSim.Path());
      Application.Run(_frmSim);
    }

    public static Simulator Instance => _instance ?? (_instance = new Simulator());

    [STAThread]
    public static void Main(string[] args)
    {
      new Simulator();
    }
    public void Initialize(string path)
    {
      Import(path);
      SetAirportPositions();
    }

    public void SetAirportPositions()
    {
      foreach (var airport in _scenario.Airports)
      {
        _frmSim.DrawAirport(airport.Position);
        SetAirplanesPositions(airport);
      }
    }

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

    private void UpdateEvents()
    {
      throw new NotImplementedException();
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
    }
  }
}