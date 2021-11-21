﻿using System.Windows.Input;
using CommonFramework.Commands;

namespace Plugin
{
    public abstract class Plugin : IPlugin
    {
        public Plugin()
        {
            Run = new RelayCommand(RelayCommandExecute, RelayCommandCanExecute);
        }
                
        public abstract string Title { get; }

        public virtual ICommand Run { get; internal set; }

        protected virtual bool RelayCommandCanExecute(object obj)
        {
            return true;
        }

        protected abstract void RelayCommandExecute(object obj);
    }
}