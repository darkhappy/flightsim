﻿using System;
using System.Windows.Forms;
using Generator.Models;

namespace Generator.Controllers
{
  public class Generator
  {
    private static Generator _instance;
    private readonly Scenario _scenario;
    private FormGenerator _frmGen;
    private FormGenerator _frmMap;

    /// <summary>
    ///   Constructor of <see cref="Generator" />
    /// </summary>
    private Generator()
    {
      _scenario = new Scenario();
    }

    /// <summary>
    ///   Singleton getter of <see cref="Generator" />
    /// </summary>
    public static Generator Instance => _instance ??= new Generator();

    /// <summary>
    ///   Entry point of the application
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
      Instance.GenerateView();
    }


    public void GenerateView()
    {
      _frmGen = new FormGenerator();
      _frmGen.UpdateAirports(_scenario.GetAirportsInfo());
      Application.Run(_frmGen);
    }

    public void UpdateAirplanes(string id)
    {
      _frmGen.UpdateAirplanes(_scenario.GetAirplanesInfo(id));
    }

    public void AddAirplane(string id, AirplaneInfo info)
    {
      _scenario.AddAirplane(id, info);
      UpdateAirplanes(id);
    }

    public void EditAirplane(string id, string[] data)
    {
      throw new NotImplementedException();
    }

    public void DeleteAirplane(string id)
    {
      throw new NotImplementedException();
    }

    /// <summary>
    ///   Call the <see cref="Scenario" /> to create a new <see cref="Airplane" /> and update the <see cref="FormGenerator" />
    /// </summary>
    /// <param name="info"><see cref="AirplaneInfo" /> to create the new <see cref="Airplane" /></param>
    public void AddAirport(AirportInfo info)
    {
      _scenario.AddAirport(info);
      _frmGen.UpdateAirports(_scenario.GetAirportsInfo());
    }

    public void EditAirport(string id, string[] data)
    {
      throw new NotImplementedException();
    }

    public void DeleteAirport(string id)
    {
      throw new NotImplementedException();
    }

    public void Export()
    {
    }

    public void Import()
    {
    }
  }
}