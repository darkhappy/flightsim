using Generator.Models;
using System;
using System.Windows.Forms;

namespace Generator.Controllers
{
  public class Generator
  {
    private readonly FormGenerator _frmGen;
    private readonly FormGenerator _frmMap;
    private Generator _instance;
    private Scenario _secenario;


    public static void Main(string[] args)
    {
      new Generator();
    }

    private Generator()
    {
      _frmGen = new FormGenerator();
      _frmGen.UpdateView();
      Application.Run(_frmGen);
    }

    public Generator Instance => _instance ?? (_instance = new Generator());


    public void AddAirplane(string id, string[] data)
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

    public void AddAirport(string[] data)
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