using System;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.SimpleChildWindow;

namespace CommonControls.Views
{
    /// <summary>
    /// Interaction logic for CustomControlWindowsHost.xaml
    /// </summary>
    public partial class CustomControlWindowsHost : ChildWindow, IModalWindow
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

        public void Show()
        {
            this.SetCurrentValue(ChildWindow.IsOpenProperty, true);
        }
    }
}