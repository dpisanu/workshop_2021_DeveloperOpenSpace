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
            Plugins = new ObservableCollection<IPlugin>(PluginLoader.LoadPlugins());
        }
    }
}
