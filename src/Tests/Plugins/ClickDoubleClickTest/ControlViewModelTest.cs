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

        [Test]
        public void DoubleclickCommand()
        {
            var vm = new Plugins.ClickDoubleClick.ControlViewModel();
            var color = vm.FieldOneColor;
            vm.ButtonOneClick.Execute(null);
            Assert.That(vm.FieldOneColor, Is.Not.EqualTo(color));
            vm.ButtonOneClick.Execute(null);
            Assert.That(vm.FieldOneColor, Is.EqualTo(color));
        }

        [Test]
        public void ButtonOneDoubleClickCommand()
        {
            var vm = new Plugins.ClickDoubleClick.ControlViewModel();
            var color = vm.FieldTwoColor;
            vm.ButtonOneDoubleClick.Execute(null);
            Assert.That(vm.FieldTwoColor, Is.Not.EqualTo(color));
            vm.ButtonOneDoubleClick.Execute(null);
            Assert.That(vm.FieldTwoColor, Is.EqualTo(color));
        }

        [Test]
        public void ButtonTwoClickCommand()
        {
            var vm = new Plugins.ClickDoubleClick.ControlViewModel();
            var color = vm.FieldTwoColor;
            vm.ButtonTwoClick.Execute(null);
            Assert.That(vm.FieldThreeColor, Is.Not.EqualTo(color));
            vm.ButtonTwoClick.Execute(null);
            Assert.That(vm.FieldThreeColor, Is.EqualTo(color));
        }

        [Test]
        public void ButtonTwoDoubleClickCommand()
        {
            var vm = new Plugins.ClickDoubleClick.ControlViewModel();
            var color = vm.FieldFourColor;
            vm.ButtonTwoDoubleClick.Execute(null);
            Assert.That(vm.FieldFourColor, Is.Not.EqualTo(color));
            vm.ButtonTwoDoubleClick.Execute(null);
            Assert.That(vm.FieldFourColor, Is.EqualTo(color));
        }
    }
}