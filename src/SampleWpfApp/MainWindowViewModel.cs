using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
        }

        public ObservableCollection<IPlugin> Plugins { get; private set; }
    }
}
