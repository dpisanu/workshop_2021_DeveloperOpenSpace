using System.Windows.Controls;
using Common.CommonControls.ViewModels;

namespace Common.CommonControls.Views
{
    public class BaseControl : UserControl
    {
        public BaseControl(IViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}