using Common.CommonControls.ViewModels;
using Common.CommonControls.Views;
using MahApps.Metro.Controls;

namespace SampleWpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : MetroWindow, IMainWindow
    {
        private readonly IViewModel _dataContext;

        public MainWindow()
        {
            _dataContext = new MainWindowViewModel();
            DataContext = _dataContext;

            InitializeComponent();
        }
    }
}