using System.Windows.Controls;
using CommonControls.Views;

namespace Plugins.Scrolling
{
    public class PluginEntry : Plugin.Plugin
    {
        private readonly UserControl _userControl;
        private readonly IModalWindow _pluginwindow;

        public PluginEntry()
        {
            _userControl = new Control();
            _pluginwindow = new CustomControlWindowsHost(_userControl);
        }

        public override string Title => "Scrolling";

        protected override void RelayCommandExecute(object obj)
        {
            _pluginwindow.Show();
        }
    }
}