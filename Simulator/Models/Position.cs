using System;
using System.Runtime.Serialization;
using Simulator.Controllers;

namespace Simulator.Models
{
  [DataContract(Namespace = "")]
  public class Position
  {
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }

    [DataMember] public int X { get; set; }

    [DataMember] public int Y { get; set; }

    public static Position GetRandomPosition()
    {
      var random = new Random();
      var x = random.Next(0, Constants.MapWidth);
      var y = random.Next(0, Constants.MapHeight);
      var position = new Position(x, y);

      return position;
    }

    public static string Transpose(int x, int y)
    {
      const int width = Constants.MapWidth;
      const int height = Constants.MapHeight;
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

    public override string ToString()
    {
      return Transpose(X, Y);
    }
  }
}