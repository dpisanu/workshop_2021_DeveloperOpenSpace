using NUnit.Framework;

namespace ContextMenuTest
{
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