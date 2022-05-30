using Generator.Models;
using NUnit.Framework;

namespace Tests.Generator
{
  [TestFixture]
  public class PositionTests
  {
    private const int width = 400;
    private const int height = 300;

    [Test]
    [TestCase(0, 0, "90° 0’ N, 180° 0’ W")]
    [TestCase(400, 0, "90° 0’ N, 180° 0’ E")]
    [TestCase(100, 0, "90° 0’ N, 90° 0’ W")]
    [TestCase(0, 300, "90° 0’ S, 180° 0’ W")]
    [TestCase(400, 300, "90° 0’ S, 180° 0’ E")]
    [TestCase(200, 150, "0° 0’ N, 0° 0’ W")]
    [TestCase(200, 45, "0° 0’ N, 0° 0’ W")]
    public void ConvertingAPositionToAString(int posX, int posY, string expected)
    {
      // Act
      var actual = Position.Transpose(posX, posY);

      // Assert
      Assert.That(actual, Is.EqualTo(expected));
    }
  }
}