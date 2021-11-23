using NUnit.Framework;

namespace ContextMenuTest
{
    [Apartment(System.Threading.ApartmentState.STA)]
    public class DragDropTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Assert.DoesNotThrow(() => new Plugins.DragDrop.PluginEntry());
        }
    }
}