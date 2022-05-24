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
  }
}