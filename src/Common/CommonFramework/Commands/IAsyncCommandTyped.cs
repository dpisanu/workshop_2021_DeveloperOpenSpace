using System.Threading.Tasks;
using System.Windows.Input;

namespace Common.CommonFramework.Commands
{
    public interface IAsyncCommand<T> : ICommand
    {
        Task ExecuteAsync(T parameter);
        bool CanExecute(T parameter);
    }
}