using NUnit.Framework;

namespace ContextMenuTest
{
    public class PluginEntryTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Assert.DoesNotThrow(() => new Plugins.ContextMenu.PluginEntry());
        }
    }
}