using System.Windows.Controls;
using CommonControls.ViewModels;

namespace CommonControls.Views
{
    public class BaseControl : UserControl
    {
        public BaseControl(IViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}