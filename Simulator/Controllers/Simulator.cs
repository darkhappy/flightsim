using System;
using System.IO;
using System.Runtime.Serialization;
using System.Windows.Forms;
using Simulator.Models;
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
      Application.Run(_frmSim);
    }

    public static Simulator Instance => _instance ?? (_instance = new Simulator());

    public static void Main(string[] args)
    {
      new Simulator();
    }

    public void OnTick(double time)
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

      // TODO: update form
    }
  }
}