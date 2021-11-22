using System.Windows.Controls;
using Common.CommonControls.ViewModels;

namespace Plugins.PopUp
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
