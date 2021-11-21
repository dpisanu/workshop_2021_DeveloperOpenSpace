using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CommonControls.ViewModels;
using CommonFramework.Commands;

namespace PopUp
{
    internal class ControlViewModel : BaseViewModels
    {
        private ImageSource _currentImage;

        private readonly ImageSource _okImage;
        private readonly ImageSource _noImage;
        private readonly ImageSource _cancelImage;

        private bool _imageVisibility = false;

        public ControlViewModel()
        {
            _okImage = new BitmapImage(new Uri("Creek.jpg", UriKind.Relative));
            _noImage = new BitmapImage(new Uri("Creek.jpg", UriKind.Relative));
            _cancelImage = new BitmapImage(new Uri("Creek.jpg", UriKind.Relative));

            PopUpCommand = new RelayCommand(PopUpCommandExecute);
        }

        public bool ImageVisibility
        {
            get => _imageVisibility;
            set => OnPropertChanged(ref _imageVisibility, value);
        }

        public ImageSource ImageSource
        {
            get => _currentImage;
            set => OnPropertChanged(ref _currentImage, value);
        }

        public ICommand PopUpCommand { get; set; }

        private void PopUpCommandExecute(object parameter)
        {
            ImageVisibility = false;

            var result = MessageBox.Show("This is a message box", "Message Box", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                ImageSource = _okImage;
            }
            else if (result == MessageBoxResult.No)
            {
                ImageSource = _noImage;
            }
            else if (result == MessageBoxResult.Cancel)
            {
                ImageSource = _cancelImage;
            }
            else { return; }

            ImageVisibility = true;
        }
    }
}