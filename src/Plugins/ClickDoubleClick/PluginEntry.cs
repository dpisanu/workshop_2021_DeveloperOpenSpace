using System.Windows.Controls;
using CommonControls.ViewModels;
using CommonControls.Views;

namespace Plugins.ClickDoubleClick
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

        public override string Title => "ClickDoubleClick";

        protected override void RelayCommandExecute(object obj)
        {
            _pluginwindow.Show();
        }
    }
}