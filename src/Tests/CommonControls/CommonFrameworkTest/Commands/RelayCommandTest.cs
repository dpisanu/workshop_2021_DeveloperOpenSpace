using System;
using Common.CommonFramework.Commands;
using NUnit.Framework;

namespace CommonFrameworkTest.Commands
{
    public class RelayCommandTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void CtorThrows()
        {
            Assert.Throws<ArgumentNullException>(() => new RelayCommand(null));
        }

        [Test]
        public void CtorDoesNotThrow()
        {
            Assert.DoesNotThrow(() => new RelayCommand(p => { }));
        }

        [Test]
        public void CanExecuteDefault()
        {
            var command = new RelayCommand(p => { });
            Assert.That(command.CanExecute(null), Is.True);
        }

        [TestCase(true)]
        [TestCase(false)]
        public void CanExecuteCustom(bool canExecuteReturnValue)
        {
            var command = new RelayCommand(p => { }, a => { return canExecuteReturnValue; });
            Assert.That(command.CanExecute(null), Is.EqualTo(canExecuteReturnValue));
        }

        [TestCase("CanExecute")]
        public void Execute(string value)
        {
            var setValue = string.Empty;
            var command = new RelayCommand(p => { setValue = value; });
            command.Execute(null);
            Assert.That(setValue, Is.EqualTo(value));
        }
    }
}