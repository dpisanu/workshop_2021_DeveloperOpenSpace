using System.Windows.Input;

namespace Plugin
{
    public interface IPlugin
    {
        string Title { get; }
        ICommand Run { get; }
    }
}