using Generator.Models;
using NUnit.Framework;

namespace Tests.Generator
{
  [TestFixture]
  public class Misc
  {
    [Test]
    public void EnsureSingleton()
    {
      var factoryOne = AirplaneFactory.Instance;
      var factoryTwo = AirplaneFactory.Instance;
      
      Assert.AreSame(factoryOne, factoryTwo);
    }
  }
}