using System.Windows.Input;
using CommonControls.ViewModels;
using CommonFramework.Commands;

namespace SelectionState
{
    public class ControlViewModel : BaseViewModels
    {
        private string _labelContent;

        public ControlViewModel()
        {
            SuperbCommand = new RelayCommand(SuperbCommandExecute);
        }

        public string LabelContent
        {
            get => _labelContent;
            set => OnPropertChanged(ref _labelContent, value);
        }
        
        public ICommand SuperbCommand { get; set; }

        private void SuperbCommandExecute(object parameter)
        {
            LabelContent = parameter.ToString();
        }
    }
}