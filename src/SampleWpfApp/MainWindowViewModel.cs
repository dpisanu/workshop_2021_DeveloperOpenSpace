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
            // Todo : Load Plugins
        }

        public ObservableCollection<IPlugin> Plugins { get; private set; }
    }
}
