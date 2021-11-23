using NUnit.Framework;

namespace SelectionStateTest
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
            Assert.DoesNotThrow(() => new Plugins.SelectionState.ControlViewModel());
        }
    }
}