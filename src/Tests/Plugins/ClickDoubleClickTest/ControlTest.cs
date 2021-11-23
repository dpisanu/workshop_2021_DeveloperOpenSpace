using NUnit.Framework;

namespace ClickDoubleClickTest
{
    [Apartment(System.Threading.ApartmentState.STA)]
    public class ControlTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Assert.DoesNotThrow(() => new Plugins.ClickDoubleClick.Control(null));
        }
    }
}