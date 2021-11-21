using System.Windows.Input;
using System.Collections.ObjectModel;
using CommonControls.ViewModels;
using CommonFramework.Commands;

namespace ListBox
{
    internal class ControlViewModel : BaseViewModels
    {
        private string _textBoxValue;

        public ControlViewModel()
        {
            ComboBoxContent = new ObservableCollection<string>
            {
                "Peppa Wutz",
                "Schorsch Wutz",
                "Opa Wutz"
            };
            AddCommand = new RelayCommand(AddToListExecute, AddToListCanExecute);
        }

        public string TextBoxValue
        {
            get => _textBoxValue;
            set => OnPropertChanged(ref _textBoxValue, value);
        }

        public ObservableCollection<string> ComboBoxContent
        {
            get;
            set;
        }

        public ICommand AddCommand { get; set; }

        private bool AddToListCanExecute(object parameter)
        {
            return !string.IsNullOrEmpty(TextBoxValue);
        }

        private void AddToListExecute(object parameter)
        {
            ComboBoxContent.Add(TextBoxValue);
        }
    }
}
