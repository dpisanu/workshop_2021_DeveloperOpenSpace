using NUnit.Framework;

namespace ContextMenuTest
{
    [Apartment(System.Threading.ApartmentState.STA)]
    public class DropDownTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Assert.DoesNotThrow(() => new Plugins.DropDown.Control(null));
        }
    }
}