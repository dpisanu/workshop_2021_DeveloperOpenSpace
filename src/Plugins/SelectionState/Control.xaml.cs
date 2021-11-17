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

namespace SelectionState
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : UserControl
    {
        public Control()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The button wpf click.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The e. </param>
        private void OnClick(object sender, RoutedEventArgs e)
        {
            var castedControl = sender as System.Windows.Controls.ContentControl;
            var castedHyperlink = sender as System.Windows.Documents.Hyperlink;

            if (castedControl != null) Label.Content = castedControl.Content;
            if (castedHyperlink != null) Label.Content = "Hyperlink";
        }
    }
}
