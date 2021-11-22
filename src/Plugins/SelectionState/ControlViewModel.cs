using System.Windows.Input;
using Common.CommonControls.ViewModels;
using Common.CommonFramework.Commands;

namespace Plugins.SelectionState
{
    internal class ControlViewModel : BaseViewModels
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