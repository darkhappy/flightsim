namespace Generator.Models
{
  public abstract class ObjectInfo
  {
    protected ObjectInfo(string id, string name)
    {
      Id = id;
      Name = name;
    }

    public string Id { get; set; }

    public string Name { get; set; }

    protected bool Equals(ObjectInfo other)
    {
      return Id == other.Id && Name == other.Name;
    }

    public override bool Equals(object? obj)
    {
      if (ReferenceEquals(null, obj)) return false;
      if (ReferenceEquals(this, obj)) return true;
      if (obj.GetType() != GetType()) return false;
      return Equals((ObjectInfo) obj);
    }

    public override int GetHashCode()
    {
      unchecked
      {
        return (Id.GetHashCode() * 397) ^ Name.GetHashCode();
      }
    }

    public static bool operator ==(ObjectInfo? left, ObjectInfo? right)
    {
      return Equals(left, right);
    }

    public static bool operator !=(ObjectInfo? left, ObjectInfo? right)
    {
      return !Equals(left, right);
    }
  }
}