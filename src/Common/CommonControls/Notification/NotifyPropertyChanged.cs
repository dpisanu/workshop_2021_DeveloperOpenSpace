using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace Common.CommonControls.Notification
{
    public abstract class NotifyPropertyChanged : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertChanged([CallerMemberName] string property = null)
        {
            var handler = PropertyChanged;
            handler?.Invoke(this, new PropertyChangedEventArgs(property));
        }

        protected void OnPropertChanged<T>(ref T field, T value, [CallerMemberName] string property = null)
        {
            field = value;
            OnPropertChanged(property);
        }
    }
}
