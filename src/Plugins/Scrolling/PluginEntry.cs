using System.Threading.Tasks;
using System.Windows.Controls;
using Common.CommonControls.Views;
using Common.Plugin;

namespace Plugins.Scrolling
{
    public class PluginEntry : PluginBase
    {
        private readonly UserControl _userControl;
        private readonly IModalWindow _pluginwindow;

        public PluginEntry()
        {
            _userControl = new Control();
            _pluginwindow = new CustomControlWindowsHost(_userControl);
        }

        public override string Title => "Scrolling";

        protected override async Task RelayCommandExecuteAsync(object obj)
        {
            await _pluginwindow.ShowAsync();
        }
    }
}