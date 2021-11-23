using NUnit.Framework;

namespace ScrollingTest
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
            Assert.DoesNotThrow(() => new Plugins.Scrolling.PluginEntry());
        }
    }
}