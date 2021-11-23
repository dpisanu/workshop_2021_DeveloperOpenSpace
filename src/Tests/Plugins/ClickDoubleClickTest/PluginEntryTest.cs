using NUnit.Framework;

namespace ClickDoubleClickTest
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
            Assert.DoesNotThrow(() => new Plugins.ClickDoubleClick.PluginEntry());
        }
    }
}