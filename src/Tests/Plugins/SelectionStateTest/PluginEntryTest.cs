using NUnit.Framework;

namespace SelectionStateTest
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
            Assert.DoesNotThrow(() => new Plugins.SelectionState.PluginEntry());
        }
    }
}