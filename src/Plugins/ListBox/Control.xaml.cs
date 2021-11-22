using System.Windows.Controls;
using CommonControls.ViewModels;

namespace Plugins.ListBox
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : UserControl
    {
        public Control(IViewModel viewModel)// : base(viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
