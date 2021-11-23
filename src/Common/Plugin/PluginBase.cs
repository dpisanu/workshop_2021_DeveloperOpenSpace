using System.Threading.Tasks;
using System.Windows.Input;
using Common.CommonFramework.Commands;

namespace Common.Plugin
{
    public abstract class PluginBase : IPlugin
    {
        public PluginBase()
        {
            Run = new AsyncRelayCommand<object>(RelayCommandExecuteAsync, RelayCommandCanExecute);
        }

        public abstract string Title { get; }

        public virtual ICommand Run { get; internal set; }

        protected virtual bool RelayCommandCanExecute(object obj)
        {
            return true;
        }

        protected abstract Task RelayCommandExecuteAsync(object obj);
    }
}