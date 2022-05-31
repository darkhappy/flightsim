using System;
using System.Linq;
using System.Reflection;
using System.Runtime.Serialization;

namespace Generator.Models
{
  /// <summary>
  ///   Abstract class representing an airplane in the simulation.
  /// </summary>
  [DataContract(Namespace = "")]
  [KnownType("GetDerivedTypes")]
  public abstract class Airplane : IExtensibleDataObject
  {
    /// <summary>
    ///   Constructor for the <see cref="Airplane" /> class.
    /// </summary>
    /// <param name="info">The information needed to create an airplane.</param>
    protected Airplane(AirplaneInfo info)
    {
      Id = info.Id;
      Name = info.Name;
      Speed = info.Speed;
      MaintenanceTime = info.MaintenanceTime;
    }

    /// <summary>
    ///   Represents the unique identifier for the <see cref="Airplane" />.
    /// </summary>
    [DataMember]
    public string Id { get; private set; }

    /// <summary>
    ///   Represents the name of the <see cref="Airplane" />.
    /// </summary>
    [DataMember]
    public string Name { get; private set; }

    /// <summary>
    ///   Represents the speed at which the <see cref="Airplane" /> can travel.
    /// </summary>
    [DataMember]
    public int Speed { get; private set; }

    /// <summary>
    ///   Represents the time it takes to perform maintenance on the <see cref="Airplane" />.
    /// </summary>
    [DataMember]
    public int MaintenanceTime { get; private set; }

    /// <summary>
    ///   Represents the type of <see cref="Airplane" />.
    /// </summary>
    /// <seealso cref="AirplaneType" />
    public abstract AirplaneType Type { get; }

    public ExtensionDataObject ExtensionData { get; set; }

    /// <summary>
    ///   Edits the <see cref="Airplane" /> information.
    /// </summary>
    /// <param name="info">The new information for the airplane.</param>
    /// <seealso cref="AirplaneInfo" />
    public virtual void Edit(AirplaneInfo info)
    {
      Id = info.Id;
      Name = info.Name;
      Speed = info.Speed;
      MaintenanceTime = info.MaintenanceTime;
    }

    public virtual AirplaneInfo ToAirplaneInfo()
    {
      return new AirplaneInfo(Id, Name, Type, Speed, MaintenanceTime);
    }

    private static Type[] GetDerivedTypes()
    {
      return Assembly.GetExecutingAssembly().GetTypes().Where(_ => _.IsSubclassOf(typeof(Airplane))).ToArray();
    }
  }
}