using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Generator.Models
{
  /// <summary>
  ///   Class representing a position in the <see cref="Scenario"/>
  /// </summary>
  [DataContract(Namespace = "")]
  public class Position
  {
    /// <summary>
    ///    Constructor for the <see cref="Position" /> class.
    /// </summary>
    /// <param name="x">Position in X</param>
    /// <param name="y">Position in Y</param>
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }

    /// <summary>
    ///   Represents the position in X of an object.   
    /// </summary>
    [DataMember] public int X { get; set; }

    /// <summary>
    ///   Represents the position in Y of an object.
    /// </summary>
    [DataMember] public int Y { get; set; }

    /// <summary>
    /// Transpose a X/Y position into a string of meridian position
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    public static string Transpose(int x, int y)
    {
      const int width = Controllers.Generator.MapWidth;
      const int height = Controllers.Generator.MapHeight;
      const int middleX = width / 2;
      const int middleY = height / 2;

      var latitude = y <= middleY ? "N" : "S";
      var longitude = x <= middleX ? "W" : "E";

      var latitudeDegrees = (double) (Math.Abs(y - middleY) * 90) / middleY;
      var longitudeDegrees = (double) (Math.Abs(x - middleX) * 180) / middleX;

      var latitudeMinutes = (int) ((latitudeDegrees - Math.Floor(latitudeDegrees)) * 60);
      var longitudeMinutes = (int) ((longitudeDegrees - Math.Floor(longitudeDegrees)) * 60);

      return
        $"{(int) latitudeDegrees}° {latitudeMinutes}’ {latitude}, {(int) longitudeDegrees}° {longitudeMinutes}’ {longitude}";
    }

    public static Position StringToPosition(string value)
    {
      const int width = Controllers.Generator.MapWidth;
      const int height = Controllers.Generator.MapHeight;
      const int middleX = width / 2;
      const int middleY = height / 2;

      string[] array = value.Split(' ', '°', '’', ',');
      List<string> values = array.ToList();
      values.RemoveAll(s => string.IsNullOrWhiteSpace(s));

      var latitudeDegrees = int.Parse(values[0]);
      var longitudeDegrees = int.Parse(values[3]);

      var latitudeMinutes = int.Parse(values[1]); 
      var longitudeMinutes = int.Parse(values[4]);

      var x = (longitudeDegrees * middleX) / 180 + middleX;
      var y = (latitudeDegrees * middleY) / 90 + middleY;

      return new Position(x, y);
    }

    /// <summary>
    /// Convert the position in string
    /// </summary>
    /// <returns><see cref="Position"/> in string</returns>
    public override string ToString()
    {
      return "x : " + X + " y : " + Y;
    }
  }
}