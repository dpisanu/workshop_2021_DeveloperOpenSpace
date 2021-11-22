using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using MahApps.Metro.SimpleChildWindow;

namespace Common.CommonControls.Views
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

        public async Task ShowAsync()
        {
            // Maybe not the best solution to get the window!
            // It could also be given by a property or parameter IHostWindow
            await Application.Current.MainWindow.ShowChildWindowAsync(this);
        }
    }
}