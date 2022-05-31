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
      var width = 400;
      var height = 300;

      // The format is
      // 180° 0’ N, 180° 0’ O
      // The top right corner (0,0) is 90° 0’ N, 180° 0’ E
      // The bottom left corner (width, height) is 90° 0’ S, 180° 0’ O
      // The top left corner (0, height) is 90° 0’ N, 180° 0’ W
      // The bottom right corner (width, 0) is 90° 0’ S, 180° 0’ O
      // And the center (width/2, height/2) is 0° 0’ N, 0° 0’ O

      var middleX = width / 2;
      var middleY = height / 2;

      var latitude = y <= middleY ? "N" : "S";
      var longitude = x <= middleX ? "W" : "E";

      var latitudeDegrees = Math.Abs(y - middleY) * 90 / middleY;
      var longitudeDegrees = Math.Abs(x - middleX) * 180 / middleX;
      var latitudeMinutes = 0;
      var longitudeMinutes = 0;

      // TODO: check minutes
      return $"{latitudeDegrees}° {latitudeMinutes}’ {latitude}, {longitudeDegrees}° {longitudeMinutes}’ {longitude}";
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