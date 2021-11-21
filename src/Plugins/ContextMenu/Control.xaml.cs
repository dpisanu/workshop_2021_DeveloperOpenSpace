using System.Windows;
using System.Windows.Controls;

namespace ContextMenu
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : UserControl
    {
        public Control()
        {
            InitializeComponent();
            ImageCancel.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// On Context Menu Visibility Changed
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void OnIsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (true.Equals(e.NewValue))
            {
                ImageOk.Visibility = ImageNo.Visibility = ImageCancel.Visibility = Visibility.Hidden;
            }
        }

        /// <summary>
        /// Menu Item Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemOk_OnClick(object sender, RoutedEventArgs e)
        {
            ImageOk.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Menu Item Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemNo_OnClick(object sender, RoutedEventArgs e)
        {
            ImageNo.Visibility = Visibility.Visible;
        }

        /// <summary>
        /// Menu Item Clicked
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuItemCancel_OnClick(object sender, RoutedEventArgs e)
        {
            ImageCancel.Visibility = Visibility.Visible;
        }
    }
}
