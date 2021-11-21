using System;
using System.Windows.Controls;
using System.Windows.Input;

namespace DragDrop
{
    /// <summary>
    /// Interaction logic for Control.xaml
    /// </summary>
    public partial class Control : UserControl
    {
        private double _mouseX;
        private double _mouseY;

        public Control()
        {
            InitializeComponent();
            Button.PreviewMouseUp += OnMouseUp;
            Button.PreviewMouseLeftButtonDown += OnMouseLeftButtonUp;
            Button.PreviewMouseMove += OnMouseMove;
        }

        // TODO : implement a dispose or hook into the window close event to deregister the Button events
        private void UnregisterEvents()
        {
            try
            {
                Button.PreviewMouseUp -= OnMouseUp;
                Button.PreviewMouseLeftButtonDown -= OnMouseLeftButtonUp;
                Button.PreviewMouseMove -= OnMouseMove;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Get the Position of Window so that it will set margin from this window
            _mouseX = e.GetPosition(this).X;
            _mouseY = e.GetPosition(this).Y;
        }

        private void OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Capture the mouse for border
                _ = e.MouseDevice.Capture(Button);
                var tempX = Convert.ToInt32(e.GetPosition(this).X);
                var tempY = Convert.ToInt32(e.GetPosition(this).Y);
                var margin = MainGrid.Margin;
                // when While moving _tempX get greater than m_MouseX relative to usercontrol 
                if (_mouseX > tempX)
                {
                    // add the difference of both to Left
                    margin.Left += tempX - _mouseX;
                    // subtract the difference of both to Left
                    margin.Right -= tempX - _mouseX;
                }
                else
                {
                    margin.Left -= _mouseX - tempX;
                    margin.Right -= tempX - _mouseX;
                }
                if (this._mouseY > tempY)
                {
                    margin.Top += tempY - _mouseY;
                    margin.Bottom -= tempY - _mouseY;
                }
                else
                {
                    margin.Top -= _mouseY - tempY;
                    margin.Bottom -= tempY - _mouseY;
                }
                MainGrid.Margin = margin;
                _mouseX = tempX;
                _mouseY = tempY;
            }
        }

        private void OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            _ = e.MouseDevice.Capture(null);
        }
    }
}
