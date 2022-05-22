namespace Generator.Models
{
  public class CargoPlane : TransportPlane
  {
    public CargoPlane(AirplaneInfo info) : base(info)
    {
    }

    public override Colour Colour => Colour.Blue;
    public override AirplaneType Type => AirplaneType.Cargo;
  }
}