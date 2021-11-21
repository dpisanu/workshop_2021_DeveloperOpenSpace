using System.Windows.Controls;
using CommonControls.ViewModels;
using CommonControls.Views;

namespace ContextMenu
{
    class PluginEntry : Plugin.Plugin
    {
        private readonly IViewModel _dataContext;
        private readonly UserControl _userControl;
        private readonly IWindow _pluginwindow;

        public PluginEntry()
        {
            _dataContext = new ControlViewModel();
            _userControl = new Control(_dataContext);
            _pluginwindow = new CustomControlWindowsHost(_userControl);
        }

        public override string Title => "ContextMenu";

        protected override void RelayCommandExecute(object obj)
        {
            _pluginwindow.Show();
        }
    }
}