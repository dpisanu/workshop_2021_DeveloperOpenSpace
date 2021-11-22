using System.Collections.ObjectModel;
using CommonControls.ViewModels;
using Plugin;

namespace SampleWpfApp
{
    internal class MainWindowViewModel : BaseViewModels
    {
        public MainWindowViewModel()
        {
            Plugins = new ObservableCollection<IPlugin>();
            LoadPlugins();
        }

        public ObservableCollection<IPlugin> Plugins { get; private set; }

        private void LoadPlugins()
        {
            Plugins.Add(new Plugins.ClickDoubleClick.PluginEntry());
            Plugins.Add(new Plugins.ContextMenu.PluginEntry());
            Plugins.Add(new Plugins.DragDrop.PluginEntry());
            Plugins.Add(new Plugins.DropDown.PluginEntry());
            Plugins.Add(new Plugins.ListBox.PluginEntry());
            Plugins.Add(new Plugins.PopUp.PluginEntry());
            Plugins.Add(new Plugins.Scrolling.PluginEntry());
            Plugins.Add(new Plugins.SelectionState.PluginEntry());
            Plugins.Add(new Plugins.Splitter.PluginEntry());
        }
    }
}
