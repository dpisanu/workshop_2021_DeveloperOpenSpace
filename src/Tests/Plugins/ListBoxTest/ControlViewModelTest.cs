using NUnit.Framework;
using System.Linq;

namespace ListBoxTest
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
            Assert.DoesNotThrow(() => new Plugins.ListBox.ControlViewModel());
        }

        [TestCase("random")]
        public void TextBoxValue(string value)
        {
            var vm = new Plugins.ListBox.ControlViewModel();
            var textBoxValue = vm.TextBoxValue;
            Assert.That(vm.TextBoxValue, Is.Not.EqualTo(value));
            vm.TextBoxValue = value;
            Assert.That(vm.TextBoxValue, Is.EqualTo(value));
        }

        [Test]
        public void ComboBoxContent()
        {
            var vm = new Plugins.ListBox.ControlViewModel();
            Assert.That(vm.ComboBoxContent.Any());
        }

        [TestCase(null, false)]
        [TestCase("", false)]
        [TestCase("random", true)]
        public void AddCommandCanExecute(string value, bool canExecute)
        {
            var vm = new Plugins.ListBox.ControlViewModel();
            vm.TextBoxValue = value;
            Assert.That(vm.AddCommand.CanExecute(null), Is.EqualTo(canExecute));
        }


        [TestCase("random")]
        public void AddCommandExecute(string value)
        {
            var vm = new Plugins.ListBox.ControlViewModel();
            Assert.That(vm.ComboBoxContent.Contains(value), Is.False);
            vm.TextBoxValue = value;
            vm.AddCommand.Execute(null);
            Assert.That(vm.ComboBoxContent.Contains(value), Is.True);
        }
    }
}