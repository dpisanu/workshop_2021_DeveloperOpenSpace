using NUnit.Framework;

namespace PopUpTest
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
            Assert.DoesNotThrow(() => new Plugins.PopUp.Control(null));
        }
    }
}