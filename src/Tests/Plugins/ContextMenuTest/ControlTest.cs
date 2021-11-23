using NUnit.Framework;

namespace ContextMenuTest
{
    public class ControlTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Assert.DoesNotThrow(() => new Plugins.ContextMenu.Control(null));
        }
    }
}