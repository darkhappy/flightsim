using System;

namespace Generator.Models
{
  public class AirplaneInfo : ObjectInfo
  {
    /// <inheritdoc cref="Airplane.MaintenanceTime" />
    private int _maintenanceTime;

    /// <inheritdoc cref="Airplane.Speed" />
    private int _speed;

    /// <summary>
    ///   Initializes a new instance of the <see cref="AirplaneInfo" /> class.
    /// </summary>
    /// <param name="id">The unique identifier of the <see cref="Airplane" />.</param>
    /// <param name="name">The name of the <see cref="Airplane" />.</param>
    /// <param name="type">The type of the <see cref="Airplane" />.</param>
    /// <param name="speed">The speed of the <see cref="Airplane" />.</param>
    /// <param name="maintenanceTime">The maintenance time of the <see cref="Airplane" />.</param>
    /// <seealso cref="AirplaneType" />
    public AirplaneInfo(string id, string name, AirplaneType type, int speed, int maintenanceTime) : base(id, name)
    {
      Type = type;
      MaintenanceTime = maintenanceTime;
      Speed = speed;
    }

    /// <summary>
    ///   Represents the type of the <see cref="Airplane" />.
    /// </summary>
    /// <seealso cref="AirplaneType" />
    public AirplaneType Type { get; set; }

    /// <inheritdoc cref="Airplane.MaintenanceTime" />
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the time is equal or below to 0.</exception>
    public int MaintenanceTime
    {
      get => _maintenanceTime;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _maintenanceTime = value;
      }
    }

    /// <inheritdoc cref="Airplane.Speed" />
    /// <exception cref="ArgumentOutOfRangeException">Thrown if the speed is equal or below to 0.</exception>
    public int Speed
    {
      get => _speed;
      set
      {
        if (value <= 0) throw new ArgumentOutOfRangeException(nameof(value));
        _speed = value;
      }
    }

    /// <summary>
    ///   Represents the maximum number of passengers or cargo that can be transported by the <see cref="TransportPlane" />.
    ///   <remarks>
    ///     An <see cref="Airplane" /> can only transport passengers or cargo if it's a <see cref="TransportPlane" />. If it is
    ///     not a <see cref="TransportPlane" />, this property will always be 0, and setting it to any value will have no
    ///     effect.
    ///   </remarks>
    /// </summary>
    public virtual double MaxCapacity
    {
      get => 0;
      set { }
    }

    /// <summary>
    ///   Represents the time it takes for a <see cref="TransportPlane" /> to embark passengers or cargo.
    ///   <remarks>
    ///     An <see cref="Airplane" /> can only embark passengers or cargo if it's a <see cref="TransportPlane" />. If it is
    ///     not a <see cref="TransportPlane" />, this property will always be 0, and setting it to any value will have no
    ///     effect.
    ///   </remarks>
    /// </summary>
    public virtual int EmbarkingTime
    {
      get => 0;
      set { }
    }

    /// <summary>
    ///   Represents the time it takes for a <see cref="TransportPlane" /> to disembark passengers or cargo.
    ///   <remarks>
    ///     An <see cref="Airplane" /> can only disembark passengers or cargo if it's a <see cref="TransportPlane" />. If it is
    ///     not a <see cref="TransportPlane" />, this property will always be 0, and setting it to any value will have no
    ///     effect.
    ///   </remarks>
    /// </summary>
    public virtual int DisembarkingTime
    {
      get => 0;
      set { }
    }
  }
}