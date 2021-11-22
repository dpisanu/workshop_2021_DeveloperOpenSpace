using System.Windows.Controls;
using System.Windows.Media;
using Common.CommonControls.ViewModels;
//using CommonControls.Views;

namespace Plugins.ClickDoubleClick
{
    /// <summary>
    ///     Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : UserControl //BaseControl
    {
        /// <summary>
        /// The white.
        /// </summary>
        private readonly SolidColorBrush _white = new SolidColorBrush(Colors.White);

        public Control(IViewModel viewModel)// : base(viewModel)
        {
            DataContext = viewModel;
            InitializeComponent();
        }
    }
}
