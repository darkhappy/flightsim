using System;

namespace Simulator.Controllers

{
  public class Simulator
  {
    private static Simulator _instance;

    private Simulator()
    {
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