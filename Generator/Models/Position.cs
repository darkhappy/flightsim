using System;
using System.Runtime.Serialization;

namespace Generator.Models
{
  [DataContract]
  public class Position
  {
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }

    public Position(string position)
    {
      Transpose(position);
    }

    [DataMember] public int X { get; set; }

    [DataMember] public int Y { get; set; }

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
      return "x : " + X + " y : " + Y;
    }
  }
}