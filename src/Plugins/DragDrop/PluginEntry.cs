using System.Windows.Controls;
using CommonControls.Views;

namespace DragDrop
{
    class PluginEntry : Plugin.Plugin
    {
        private readonly UserControl _userControl;
        private readonly IWindow _pluginwindow;

        public PluginEntry()
        {
            _userControl = new Control();
            _pluginwindow = new CustomControlWindowsHost(_userControl);
        }

        public override string Title => "DragDrop";

        protected override void RelayCommandExecute(object obj)
        {
            _pluginwindow.Show();
        }
    }
}