using NUnit.Framework;

namespace ContextMenuTest
{
    public class ControlViewModelTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Assert.DoesNotThrow(() => new Plugins.ContextMenu.ControlViewModel());
        }
    }
}