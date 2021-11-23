using NUnit.Framework;

namespace SelectionStateTest
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
            Assert.DoesNotThrow(() => new Plugins.SelectionState.Control(null));
        }
    }
}