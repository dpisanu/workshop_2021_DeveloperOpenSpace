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
            Button.PreviewMouseUp += this.DraggingButtonWPF_OnMouseUp;
            Button.PreviewMouseLeftButtonDown += this.DraggingButtonWPF_OnMouseLeftButtonUp;
            Button.PreviewMouseMove += this.DraggingButtonWPF_OnMouseMove;
        }

        private void DraggingWindowWpfNameClosing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            try
            {
                Button.PreviewMouseUp -= this.DraggingButtonWPF_OnMouseUp;
                Button.PreviewMouseLeftButtonDown -= this.DraggingButtonWPF_OnMouseLeftButtonUp;
                Button.PreviewMouseMove -= this.DraggingButtonWPF_OnMouseMove;
            }
            catch (Exception)
            {
                ;
            }
        }

        private void DraggingButtonWPF_OnMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            // Get the Position of Window so that it will set margin from this window
            this._mouseX = e.GetPosition(this).X;
            this._mouseY = e.GetPosition(this).Y;
        }

        private void DraggingButtonWPF_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (e.LeftButton == MouseButtonState.Pressed)
            {
                // Capture the mouse for border
                e.MouseDevice.Capture(Button);
                var tempX = Convert.ToInt32(e.GetPosition(this).X);
                var tempY = Convert.ToInt32(e.GetPosition(this).Y);
                var margin = this.MainGrid.Margin;
                // when While moving _tempX get greater than m_MouseX relative to usercontrol 
                if (this._mouseX > tempX)
                {
                    // add the difference of both to Left
                    margin.Left += tempX - this._mouseX;
                    // subtract the difference of both to Left
                    margin.Right -= tempX - this._mouseX;
                }
                else
                {
                    margin.Left -= this._mouseX - tempX;
                    margin.Right -= tempX - this._mouseX;
                }
                if (this._mouseY > tempY)
                {
                    margin.Top += tempY - this._mouseY;
                    margin.Bottom -= tempY - this._mouseY;
                }
                else
                {
                    margin.Top -= this._mouseY - tempY;
                    margin.Bottom -= tempY - this._mouseY;
                }
                MainGrid.Margin = margin;
                this._mouseX = tempX;
                this._mouseY = tempY;
            }
        }

        private void DraggingButtonWPF_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            e.MouseDevice.Capture(null);
        }
    }
}
