using System.Threading.Tasks;
using System.Windows.Controls;
using CommonControls.ViewModels;
using CommonControls.Views;

namespace Plugins.PopUp
{
    public class PluginEntry : Plugin.Plugin
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

        public override string Title => "PopUp";

        protected override async Task RelayCommandExecuteAsync(object obj)
        {
            await _pluginwindow.ShowAsync();
        }
    }
}