using System;

namespace Generator.Models
{
  public class Position
  {
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }

    public int X { get; set; }

    public int Y { get; set; }

    public static string Transpose(int x, int y)
    {
      throw new NotImplementedException();
    }

    public static Tuple<int, int> Transpose(string position)
    {
      throw new NotImplementedException();
    }

    public override string ToString()
    {
      throw new NotImplementedException();
    }
  }
}