using System.Windows.Controls;
using Common.CommonControls.ViewModels;

namespace Common.CommonControls.Views
{
    public abstract class BaseControl : UserControl
    {
        public BaseControl(IViewModel viewModel)
        {
            DataContext = viewModel;
        }
    }
}