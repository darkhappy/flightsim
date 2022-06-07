namespace Simulator.Models
{
  /// <summary>
  ///   Represents information about an object.
  /// </summary>
  public class ObjectInfo
  {
    /// <summary>
    ///   Constructor of the <see cref="ObjectInfo" />
    /// </summary>
    /// <param name="id">The unique identifier of an <see cref="ObjectInfo" /></param>
    /// <param name="name">The name of an <see cref="ObjectInfo" /></param>
    public ObjectInfo(string id, string name)
    {
      Id = id;
      Name = name;
    }

    /// <summary>
    ///   Represents the unique identifier for the <see cref="ObjectInfo" />.
    /// </summary>
    public string Id { get; }

    /// <summary>
    ///   Represents the name for the <see cref="ObjectInfo" />.
    /// </summary>
    public string Name { get; }

    /// <summary>
    ///   Determines if two <see cref="ObjectInfo" /> are equal
    /// </summary>
    /// <param name="other">The <see cref="ObjectInfo" /> that will be compared to the actual object</param>
    /// <returns>Whether the two object are equal</returns>
    protected bool Equals(ObjectInfo other)
    {
      return Id == other.Id && Name == other.Name;
    }

    /// <summary>
    ///   Determines if the current <see cref="ObjectInfo" /> is equal to another object
    /// </summary>
    /// <param name="obj">The object that will be compared to the actual object</param>
    /// <returns>Whether the two object are equal</returns>
    public override bool Equals(object? obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((ObjectInfo) obj);
    }

    /// <summary>
    ///   Represents the HashCode for the <see cref="ObjectInfo" /> useful for Equals().
    /// </summary>
    public override int GetHashCode()
    {
      unchecked
      {
        return (Id.GetHashCode() * 397) ^ Name.GetHashCode();
      }
    }

    /// <summary>
    ///   Check if two <see cref="ObjectInfo" /> are equal
    /// </summary>
    /// <param name="left">The first <see cref="ObjectInfo" /> compared</param>
    /// <param name="right">The second <see cref="ObjectInfo" /> compared</param>
    /// <returns>Whether the two object are equal</returns>
    public static bool operator ==(ObjectInfo? left, ObjectInfo? right)
    {
      return Equals(left, right);
    }

    /// <summary>
    ///   Check if two <see cref="ObjectInfo" /> are not equal
    /// </summary>
    /// <param name="left">The first <see cref="ObjectInfo" /> compared</param>
    /// <param name="right">The second <see cref="ObjectInfo" /> compared</param>
    /// <returns>Whether the two object are not equal</returns>
    public static bool operator !=(ObjectInfo? left, ObjectInfo? right)
    {
      return !Equals(left, right);
    }
  }
}