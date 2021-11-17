
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace ClickDoubleClick
{
    /// <summary>
    ///     Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : UserControl
    {
        /// <summary>
        /// The white.
        /// </summary>
        private readonly SolidColorBrush _white = new SolidColorBrush(Colors.White);

        public Control()
        {
            InitializeComponent();
        }

        /// <summary>
        /// The button 01 mouse double click.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The e. </param>
        private void Button01MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentColor = Rectangle02.Fill as SolidColorBrush;
            Rectangle02.Fill = currentColor != null && currentColor.Color == this._white.Color ? new SolidColorBrush(Colors.Red) : this._white;

            var currentVisibility = Image02.Visibility;
            Image02.Visibility = currentVisibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        /// <summary>
        /// The button 02 mouse double click.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The e. </param>
        private void Button02MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var currentColor = Rectangle04.Fill as SolidColorBrush;
            Rectangle04.Fill = currentColor != null && currentColor.Color == this._white.Color ? new SolidColorBrush(Colors.Red) : this._white;

            var currentVisibility = Image04.Visibility;
            Image04.Visibility = currentVisibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        /// <summary>
        /// The button 01 click.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The e. </param>
        private void Button01Click(object sender, RoutedEventArgs e)
        {
            var currentColor = Rectangle01.Fill as SolidColorBrush;
            Rectangle01.Fill = currentColor != null && currentColor.Color == this._white.Color ? new SolidColorBrush(Colors.Blue) : this._white;

            var currentVisibility = Image01.Visibility;
            Image01.Visibility = currentVisibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }

        /// <summary>
        /// The button 02 click.
        /// </summary>
        /// <param name="sender"> The sender. </param>
        /// <param name="e"> The e. </param>
        private void Button02Click(object sender, RoutedEventArgs e)
        {
            var currentColor = Rectangle03.Fill as SolidColorBrush;
            Rectangle03.Fill = currentColor != null && currentColor.Color == this._white.Color ? new SolidColorBrush(Colors.Blue) : this._white;

            var currentVisibility = Image03.Visibility;
            Image03.Visibility = currentVisibility == Visibility.Hidden ? Visibility.Visible : Visibility.Hidden;
        }
    }
}
