using NUnit.Framework;

namespace SelectionStateTest
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
            Assert.DoesNotThrow(() => new Plugins.SelectionState.Control(null));
        }
    }
}