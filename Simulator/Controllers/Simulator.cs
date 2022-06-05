﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Generator.Models;
using Simulator.Models;
using Simulator.Views;

namespace Simulator.Controllers

{
  public class Simulator
  {
    private static Simulator _instance;
    private readonly FormSimulator _frmSim;
    private Scenario _scenario;

    /// <summary>
    /// Constructor of a singleton instance of Simulator
    /// </summary>
    private Simulator()
    {
      _scenario = new Scenario();
      _frmSim = new FormSimulator();
    }

    /// <summary>
    /// Checks if there is alredy an existing instance of Simulator, if not, it creates one
    /// </summary>
    public static Simulator Instance => _instance ??= new Simulator();

    /// <summary>
    /// Entry point of the Simulator program
    /// </summary>
    /// <param name="args"></param>
    [STAThread]
    public static void Main(string[] args)
    {
      Instance.GenerateView();
    }

    /// <summary>
    /// 
    /// </summary>
    private void GenerateView()
    {
      var path = _frmSim.Path();
      if (path == "")
        return;

      Import(path);
      _scenario.GenerateTasks();
      Application.Run(_frmSim);

    }

    /// <summary>
    /// Takes all airports from the scenario airports list and places them on the map.
    /// </summary>
    public List<Tuple<string, Position>> AirportPositions()
    {
      var list = new List<Tuple<string, Position>>();
      foreach (var airport in _scenario.Airports)
      {
        list.Add(new Tuple<string, Position>(airport.Name, airport.Position));
      }
     return list;
    }

    /// <summary>
    /// Takes all airports from the scenario airports list and places them on the map.
    /// </summary>
    public List<ObjectInfo> Airports()
    {
      return _scenario.GetAirportsObjectInfo();
    }

    /// <summary>
    /// Takes all airports from the scenario airports list and places them on the map.
    /// </summary>
    public List<string> AirplanesFromAirportId(string id)
    {
      return _scenario.GetAirplanesFromAirport(id);
    }

    /// <summary>
    /// Returns the list of clients.
    /// </summary>
    /// <returns>
    /// List of clients.
    /// </returns>
    public List<string> Clients(string id)
    {
      return _scenario.GetClients(id);
    }

    /// <summary>
    /// It makes all the actions to be made in a given time from the scenario.
    /// </summary>
    /// <param name="time">
    /// Time given in wich the scenario gets updated
    /// </param>
    public void OnTick(int time)
    {
      //Generate events
      if (CanGenerate(time))
        _scenario.GenerateTasks();
      
      //Make all actions 
      _scenario.HandleTick(time);

      //Draw actions results
      _frmSim.DrawMap();
      UpdateEvents(_scenario.GetEvents());
      UpdateAirplanes(_scenario.GetFlyingAirplanes());
    }

    /// <summary>
    /// Returns true if Scenario can generate tasks.
    /// </summary>
    /// <returns>
    /// A bool.
    /// </returns>
    private bool CanGenerate(int time)
    {
      return time % 3600 == 0;
    }

    /// <summary>
    /// Make updates to all events
    /// </summary>
    /// <exception cref="NotImplementedException"></exception>
    public void UpdateEvents(List<Tuple<TaskType, Position>> events)
    {
      foreach(Tuple<TaskType, Position> task in events)
      {
        _frmSim.DrawEvent(task);
      }
    }

    public void UpdateAirplanes(List<Tuple<TaskType, Position, Position, Position>> airplanes)
    {
      foreach(var airplane in airplanes)
      {
        _frmSim.DrawAirplane(airplane.Item1, airplane.Item2, airplane.Item3, airplane.Item4);
      }
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