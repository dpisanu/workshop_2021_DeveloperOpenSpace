using NUnit.Framework;

namespace SampleWpfAppTest
{
    public class MainWindowViewModelTest
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