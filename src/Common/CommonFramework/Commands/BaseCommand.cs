using System;
using System.Windows.Input;

namespace CommonFramework.Commands
{
    public abstract class BaseCommand : ICommand
    {
        private EventHandler _canExecuteChanged;

        public virtual event EventHandler CanExecuteChanged
        {
            add
            {
                _canExecuteChanged += value;
            }
            remove
            {
                _canExecuteChanged -= value;
            }
        }

        public virtual bool CanExecute(object parameter)
        {
            return true;
        }

        public abstract void Execute(object parameter);
    }
}
