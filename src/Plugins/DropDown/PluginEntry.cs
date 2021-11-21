using System.Windows.Controls;
using CommonControls.ViewModels;
using CommonControls.Views;

namespace DropDown
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

        public override string Title => "DropDown";

        protected override void RelayCommandExecute(object obj)
        {
            _pluginwindow.Show();
        }
    }
}