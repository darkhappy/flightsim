using System;
using System.Runtime.Serialization;

namespace Generator.Models
{
  /// <summary>
  ///   Abstract class representing a plane that transports things.
  /// </summary>
  [DataContract(Namespace = "")]
  public abstract class TransportPlane : Airplane
  {
    /// <summary>
    ///   Constructor for the <see cref="TransportPlane" /> class.
    /// </summary>
    /// <param name="info">The information needed to create an airplane.</param>
    protected TransportPlane(AirplaneInfo info) : base(info)
    {
      if (info.MaxCapacity <= 0)
        throw new ArgumentOutOfRangeException(nameof(info.MaxCapacity),
          @"Max capacity cannot be less than or equal to 0");

      MaxCapacity = info.MaxCapacity;
      EmbarkingTime = info.EmbarkingTime;
      DisembarkingTime = info.DisembarkingTime;
    }

    /// <summary>
    ///   Represents the max capacity of cargo or passenger that can be transported on the <see cref="Airplane" />.
    /// </summary>
    [DataMember]
    public double MaxCapacity { get; private set; }

    /// <summary>
    ///   Represents the embarking time for each cargo or passenger on the <see cref="Airplane" />.
    /// </summary>
    [DataMember]
    public int EmbarkingTime { get; private set; }

    /// <summary>
    ///   Represents the disembarking time for each cargo or passenger on the <see cref="Airplane" />.
    /// </summary>
    [DataMember]
    public int DisembarkingTime { get; private set; }

    /// <summary>
    ///   Edits the <see cref="TransportPlane" /> information.
    /// </summary>
    /// <param name="info">The new information for the airplane.</param>
    /// <seealso cref="AirplaneInfo" />
    /// <seealso cref="CargoPlane" />
    /// <seealso cref="PassengerPlane" />
    public override void Edit(AirplaneInfo data)
    {
      base.Edit(data);

      var info = (TransportInfo) data;

      MaxCapacity = info.MaxCapacity;
      EmbarkingTime = info.EmbarkingTime;
      DisembarkingTime = info.DisembarkingTime;
    }

    /// <summary>
    ///   Represents the information of the <see cref="TransportPlane"/>
    /// </summary>
    /// <returns>The <see cref="AirplaneInfo"/> of the <see cref="Airplane"/></returns>
    public override AirplaneInfo ToAirplaneInfo()
    {
      return new TransportInfo(Id, Name, Type, Speed, MaintenanceTime, MaxCapacity, EmbarkingTime, DisembarkingTime);
    }
  }
}