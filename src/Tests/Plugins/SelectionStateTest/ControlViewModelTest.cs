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

        [TestCase("random")]
        public void LabelContent(string value)
        {
            var vm = new Plugins.SelectionState.ControlViewModel();
            Assert.That(vm.LabelContent, Is.Not.EqualTo(value));
            vm.LabelContent = value;
            Assert.That(vm.LabelContent, Is.EqualTo(value));
        }

        [TestCase("random")]
        public void SuperbCommandExecute(string value)
        {
            var vm = new Plugins.SelectionState.ControlViewModel();
            Assert.That(vm.LabelContent, Is.Not.EqualTo(value));
            vm.SuperbCommand.Execute(value);
            Assert.That(vm.LabelContent, Is.EqualTo(value));
        }
    }
}