using NUnit.Framework;
using System.Linq;

namespace DropDownTest
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
            Assert.DoesNotThrow(() => new Plugins.DropDown.ControlViewModel());
        }

        [Test]
        public void ComboBoxContent()
        {
            var vm = new Plugins.DropDown.ControlViewModel();
            Assert.That(vm.ComboBoxContent.Any());
        }

        [TestCase("random")]
        public void TextBoxValue(string value)
        {
            var vm = new Plugins.DropDown.ControlViewModel();
            var textBoxValue = vm.TextBoxValue;
            Assert.That(vm.TextBoxValue, Is.Not.EqualTo(value));
            vm.TextBoxValue = value;
            Assert.That(vm.TextBoxValue, Is.EqualTo(value));
        }

        [TestCase("random")]
        public void SelectedItem(string value)
        {
            var vm = new Plugins.DropDown.ControlViewModel();
            var textBoxValue = vm.SelectedItem;
            Assert.That(vm.TextBoxValue, Is.Not.EqualTo(value));
            vm.TextBoxValue = value;
            Assert.That(vm.TextBoxValue, Is.EqualTo(value));
        }
    }
}