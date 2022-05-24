using Generator.Models;
using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Generator.Controllers
{
  public class Generator
  {
    private readonly FormGenerator _frmGen;
    private readonly FormGenerator _frmMap;
    private static Generator _instance;
    private Scenario _scenario;

    /// <summary>
    /// Entry point of the application
    /// </summary>
    /// <param name="args"></param>
    public static void Main(string[] args)
    {
      new Generator();
    }

    private Generator()
    {
      _scenario = new Scenario();
      _frmGen = new FormGenerator();
      _frmGen.UpdateView(_scenario.GetAirportsInfo());
      Application.Run(_frmGen);
    }

    public static Generator Instance => _instance ??= new Generator();


    public void AddAirplane(string id, AirplaneInfo info)
    {
      throw new NotImplementedException();
    }

    public void EditAirplane(string id, string[] data)
    {
      throw new NotImplementedException();
    }

    public void DeleteAirplane(string id)
    {
      throw new NotImplementedException();
    }

    public void AddAirport(AirportInfo info)
    {
      throw new NotImplementedException();
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