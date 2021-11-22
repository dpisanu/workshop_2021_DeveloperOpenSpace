using System.Threading.Tasks;
using System.Windows.Controls;
using Common.CommonControls.ViewModels;
using Common.CommonControls.Views;
using Common.Plugin;

namespace Plugins.ContextMenu
{
    public class PluginEntry : PluginBase
    {
        private readonly IViewModel _dataContext;
        private readonly UserControl _userControl;
        private readonly IModalWindow _pluginwindow;

        public PluginEntry()
        {
            _dataContext = new ControlViewModel();
            _userControl = new Control(_dataContext);
            _pluginwindow = new CustomControlWindowsHost(_userControl);
        }

        public override string Title => "ContextMenu";

        protected override async Task RelayCommandExecuteAsync(object obj)
        {
            await _pluginwindow.ShowAsync();
        }
    }
}