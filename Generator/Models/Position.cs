using System;
using System.Runtime.Serialization;

namespace Generator.Models
{
  [DataContract(Namespace = "")]
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
      // Width and height of the map
      // TODO: bind this to the map size
      var width = 400;
      var height = 300;

      var middleX = width / 2;
      var middleY = height / 2;

      var latitude = y <= middleY ? "N" : "S";
      var longitude = x <= middleX ? "W" : "E";

      var latitudeDegrees = (double) (Math.Abs(y - middleY) * 90) / middleY;
      var longitudeDegrees = (double) (Math.Abs(x - middleX) * 180) / middleX;

      var latitudeMinutes = (int) ((latitudeDegrees - Math.Floor(latitudeDegrees)) * 60);
      var longitudeMinutes = (int) ((longitudeDegrees - Math.Floor(longitudeDegrees)) * 60);

      return
        $"{(int) latitudeDegrees}° {latitudeMinutes}’ {latitude}, {(int) longitudeDegrees}° {longitudeMinutes}’ {longitude}";
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