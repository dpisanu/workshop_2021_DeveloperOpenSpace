using NUnit.Framework;

namespace SampleWpfAppTest
{
    [Apartment(System.Threading.ApartmentState.STA)]
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