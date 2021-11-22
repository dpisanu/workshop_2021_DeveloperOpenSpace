using System.Windows.Input;

namespace Common.Plugin
{
    public interface IPlugin
    {
        string Title { get; }
        ICommand Run { get; }
    }
}