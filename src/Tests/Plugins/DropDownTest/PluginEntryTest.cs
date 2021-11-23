using NUnit.Framework;

namespace DropDownTest
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
            Assert.DoesNotThrow(() => new Plugins.DropDown.PluginEntry());
        }
    }
}