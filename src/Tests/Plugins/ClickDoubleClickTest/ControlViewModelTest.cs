using NUnit.Framework;

namespace ClickDoubleClickTest
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
            Assert.DoesNotThrow(() => new Plugins.ClickDoubleClick.ControlViewModel());
        }
    }
}