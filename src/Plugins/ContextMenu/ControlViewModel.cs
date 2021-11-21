using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using CommonControls.ViewModels;
using CommonFramework.Commands;

namespace ContextMenu
{
    public class ContextMenu : BaseViewModels
    {
        private ImageSource _currentImage;

        private readonly ImageSource _okImage;
        private readonly ImageSource _noImage;
        private readonly ImageSource _cancelImage;

        private bool _imageVisibility = false;

        public ContextMenu()
        {
            _okImage = new BitmapImage(new Uri("Creek.jpg", UriKind.Relative));
            _noImage = new BitmapImage(new Uri("Creek.jpg", UriKind.Relative));
            _cancelImage = new BitmapImage(new Uri("Creek.jpg", UriKind.Relative));

            PopUpCommand = new RelayCommand(PopUpCommandExecute);
            ContextMenuOkCommand = new RelayCommand(ContextMenuOkCommandExecute);
            ContextMenuNoCommand = new RelayCommand(ContextMenuNoCommandExecute);
            ContextMenuCancelCommand = new RelayCommand(ContextMenuCancelCommandExecute);
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
        public ICommand ContextMenuOkCommand { get; set; }
        public ICommand ContextMenuNoCommand { get; set; }
        public ICommand ContextMenuCancelCommand { get; set; }

        private void PopUpCommandExecute(object parameter)
        {
            ImageVisibility = false;

            var result = MessageBox.Show("This is a message box", "Message Box", MessageBoxButton.YesNoCancel);
            if (result == MessageBoxResult.Yes)
            {
                ImageSource = _okImage;
            }
            if (result == MessageBoxResult.No)
            {
                ImageSource = _noImage;
            }
            if (result == MessageBoxResult.Cancel)
            {
                ImageSource = _cancelImage;
            }

            ImageVisibility = true;
        }

        private void ContextMenuOkCommandExecute(object parameter)
        {
            ContextMenuCommandExecute(_okImage);
        }
        private void ContextMenuNoCommandExecute(object parameter)
        {
            ContextMenuCommandExecute(_noImage);
        }
        private void ContextMenuCancelCommandExecute(object parameter)
        {
            ContextMenuCommandExecute(_cancelImage);
        }

        private void ContextMenuCommandExecute(ImageSource image)
        {
            ImageVisibility = false;
            ImageSource = image;
            ImageVisibility = true;
        }
    }
}
