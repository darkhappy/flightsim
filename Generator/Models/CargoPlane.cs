namespace Generator.Models
{
  public class CargoPlane : TransportPlane
  {
    public CargoPlane(AirplaneInfo info) : base(info)
    {
    }

    private CargoPlane()
    {
    }

    public override AirplaneType Type => AirplaneType.Cargo;
  }
}