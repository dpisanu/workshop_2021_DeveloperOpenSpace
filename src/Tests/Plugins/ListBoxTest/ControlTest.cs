using NUnit.Framework;

namespace ListBoxTest
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
            Assert.DoesNotThrow(() => new Plugins.ListBox.Control(null));
        }
    }
}