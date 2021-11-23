using NUnit.Framework;

namespace SplitterTest
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
            Assert.DoesNotThrow(() => new Plugins.Splitter.Control());
        }
    }
}