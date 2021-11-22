using System.Windows;
using System.Windows.Controls;
using CommonControls.ViewModels;

namespace Plugins.ContextMenu
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

        // <summary>
        /// On Context Menu Visibility Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (true.Equals(e.NewValue))
            {
                ReactionImage.Visibility = Visibility.Hidden;
            }
        }
    }
}