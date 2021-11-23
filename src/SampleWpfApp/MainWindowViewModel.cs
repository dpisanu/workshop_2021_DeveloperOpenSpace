using System.Collections.ObjectModel;
using Common.CommonControls.ViewModels;
using Common.Plugin;

namespace SampleWpfApp
{
    public class MainWindowViewModel : BaseViewModels
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
