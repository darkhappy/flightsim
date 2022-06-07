using System;
using System.Runtime.Serialization;
using Simulator.Controllers;

namespace Simulator.Models
{
  /// <summary>
  ///   Class representing a position in the <see cref="Scenario" />
  /// </summary>
  [DataContract(Namespace = "")]
  public class Position : IEquatable<Position>
  {
    /// <summary>
    ///   Random number generator
    /// </summary>
    /// <remarks>This is static as the method that uses it is also static, and it would've not generated valid random numbers.</remarks>
    private static readonly Random Random = new Random();

    /// <summary>
    ///   Constructor for the <see cref="Position" /> class.
    /// </summary>
    /// <param name="x">Position in X</param>
    /// <param name="y">Position in Y</param>
    public Position(int x, int y)
    {
      X = x;
      Y = y;
    }

    /// <summary>
    ///   Checks if the position is hidden (ie. at -1,-1)
    /// </summary>
    public bool Hidden => Equals(new Position(-1, -1));

    /// <summary>
    ///   Represents the position in X of an object.
    /// </summary>
    [DataMember]
    public int X { get; set; }

    /// <summary>
    ///   Represents the position in Y of an object.
    /// </summary>
    [DataMember]
    public int Y { get; set; }

    public bool Equals(Position? other)
    {
      if (ReferenceEquals(null, other)) return false;
      if (ReferenceEquals(this, other)) return true;
      return X == other.X && Y == other.Y;
    }

    public override bool Equals(object? obj)
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

    public static bool operator ==(Position? left, Position? right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(Position? left, Position? right)
    {
      return !Equals(left, right);
    }

    public static Position GetRandomPosition()
    {
      var x = Random.Next(0, Constants.MapWidth);
      var y = Random.Next(0, Constants.MapHeight);
      var position = new Position(x, y);

      return position;
    }

    /// <summary>
    ///   Transpose a X/Y position into a string of meridian position
    /// </summary>
    /// <param name="x"></param>
    /// <param name="y"></param>
    /// <returns></returns>
    private static string Transpose(int x, int y)
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

    /// <summary>
    ///   Convert the position in string
    /// </summary>
    /// <returns><see cref="Position" /> in string</returns>
    public override string ToString()
    {
      return Transpose(X, Y);
    }

    /// <summary>
    ///   Gets the distance between this position and another position
    /// </summary>
    /// <param name="target">The target position</param>
    /// <returns>The distance between this position and another position</returns>
    public double DistanceTo(Position target)
    {
      var distanceX = target.X - X;
      var distanceY = target.Y - Y;

      return Math.Sqrt(Math.Pow(distanceX, 2) + Math.Pow(distanceY, 2));
    }
  }
}