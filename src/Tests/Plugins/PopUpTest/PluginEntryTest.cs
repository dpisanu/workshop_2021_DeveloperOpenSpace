using NUnit.Framework;

namespace PopUpTest
{
    [Apartment(System.Threading.ApartmentState.STA)]
    public class PluginEntryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Assert.DoesNotThrow(() => new Plugins.PopUp.PluginEntry());
        }
    }
}