using NUnit.Framework;

namespace ScrollingTest
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
            Assert.DoesNotThrow(() => new Plugins.Scrolling.Control());
        }
    }
}