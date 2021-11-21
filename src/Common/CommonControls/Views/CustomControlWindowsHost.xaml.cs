using System;
using System.Windows;
using System.Windows.Controls;

namespace CommonControls.Views
{
    /// <summary>
    /// Interaction logic for CustomControlWindowsHost.xaml
    /// </summary>
    public partial class CustomControlWindowsHost : Window, IWindow
    {
        public CustomControlWindowsHost(UserControl guestControl)
        {
            if (guestControl == null)
            {
                throw new Exception("User Control is null");
            }
            InitializeComponent();
            LayoutRoot.Children.Add(guestControl);
        }
    }
}
