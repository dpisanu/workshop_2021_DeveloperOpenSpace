using System.Windows.Controls;
using CommonControls.Views;

namespace Splitter
{
    class PluginEntry : Plugin.Plugin
    {
        private readonly UserControl _userControl;
        private readonly IModalWindow _pluginwindow;

        public PluginEntry()
        {
            _userControl = new Control();
            _pluginwindow = new CustomControlWindowsHost(_userControl);
        }

        public override string Title => "Splitter";

        protected override void RelayCommandExecute(object obj)
        {
            _pluginwindow.Show();
        }
    }
}