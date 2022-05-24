namespace Generator.Models
{
  public class CargoPlane : TransportPlane
  {
    public CargoPlane(AirplaneInfo info) : base(info)
    {
    }

    public override AirplaneType Type => AirplaneType.Cargo;
  }
}