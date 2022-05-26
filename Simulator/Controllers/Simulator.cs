using System;
using System.Windows.Forms;
using Simulator.Views;

namespace Simulator.Controllers

{
  public class Simulator
  {
    private static Simulator _instance;
    private readonly FormSimulator _frmSim;

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
  }
}