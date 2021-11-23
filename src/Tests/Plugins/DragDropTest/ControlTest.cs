using NUnit.Framework;

namespace DragDropTest
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
            Assert.DoesNotThrow(() => new Plugins.DragDrop.Control());
        }
    }
}