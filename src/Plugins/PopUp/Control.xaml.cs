using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace PopUp
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : UserControl
    {
        public Control()
        {
            InitializeComponent();
            ImageOk.Visibility = Visibility.Hidden;
            ImageNo.Visibility = Visibility.Hidden;
            ImageCancel.Visibility = Visibility.Hidden;
        }

        /// <summary>
        /// The button click.
        /// </summary>
        /// <param name="sender">  The sender.  </param>
        /// <param name="e">  The e.  </param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            ImageOk.Visibility = ImageNo.Visibility = ImageCancel.Visibility = Visibility.Hidden;

            var result = MessageBox.Show("This is a message box", "Message Box", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                ImageOk.Visibility = Visibility.Visible;
            }
            if (result == MessageBoxResult.No)
            {
                ImageNo.Visibility = Visibility.Visible;
            }
            if (result == MessageBoxResult.Cancel)
            {
                ImageCancel.Visibility = Visibility.Visible;
            }
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
