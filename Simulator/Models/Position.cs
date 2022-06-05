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

    protected bool Equals(Position other)
    {
      return X == other.X && Y == other.Y;
    }

    public override bool Equals(object obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((Position) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (X * 397) ^ Y;
      }
    }

    public static bool operator ==(Position left, Position right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Position left, Position right)
    {
      return !Equals(left, right);
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

    public double DistanceTo(Position target)
    {
      var distanceX = target.X - X;
      var distanceY = target.Y - Y;

      return Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
    }
  }
}