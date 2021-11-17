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

namespace DropDown
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : UserControl
    {
        public Control()
        {
            InitializeComponent();
            (DataContext as MainWindowViewModel).ComboBoxContent.Add("123456789");
            (DataContext as MainWindowViewModel).ComboBoxContent.Add("321654987");
            (DataContext as MainWindowViewModel).ComboBoxContent.Add("000000000");
        }

        /// <summary>
        /// On Selection Changed for Combo Box
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ComboBoxOnSelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (e.AddedItems.Count > 0)
            {
                TextBox.Text = e.AddedItems[0].ToString();
            }
        }

        /// <summary>
        /// The button add name click.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The e. </param>
        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            var viewModel = this.DataContext as MainWindowViewModel;
            if (viewModel == null)
            {
                return;
            }

            if (string.IsNullOrEmpty(viewModel.TextBoxName))
            {
                return;
            }

            viewModel.ObservableCollectionName.Add(viewModel.TextBoxName);
            viewModel.TextBoxName = string.Empty;
        }
    }
}
