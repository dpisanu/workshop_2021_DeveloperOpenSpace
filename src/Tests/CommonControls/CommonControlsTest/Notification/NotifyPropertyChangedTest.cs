using Common.CommonControls.Notification;
using NUnit.Framework;

namespace CommonControlsTest.Common
{
    public class NotifyPropertyChangedTest
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Ctor()
        {
            Assert.DoesNotThrow(() => new NotificationSample());
        }

        [TestCase(true)]
        [TestCase(false)]
        public void SetState(bool state)
        {
            var notifier = new NotificationSample();
            notifier.State = state;
            Assert.That(notifier.State, Is.EqualTo(state));
        }
    }

    internal class NotificationSample : NotifyPropertyChanged
    {
        private bool _state = false;

        public bool State
        {
            get => _state;
            set => OnPropertChanged(ref _state, value);
        }
    }
}