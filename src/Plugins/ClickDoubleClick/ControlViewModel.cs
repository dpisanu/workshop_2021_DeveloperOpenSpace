using System.Windows.Input;
using System.Windows.Media;
using CommonControls.ViewModels;
using CommonFramework.Commands;

namespace ClickDoubleClick
{
    public class ControlViewModel : BaseViewModels
    {
        private readonly SolidColorBrush _defaultColor = new SolidColorBrush(Colors.White);
        private readonly SolidColorBrush _redColor = new SolidColorBrush(Colors.Red);
        private readonly SolidColorBrush _blueColor = new SolidColorBrush(Colors.Blue);
        private SolidColorBrush _fieldOneColor;
        private SolidColorBrush _fieldTwoColor;
        private SolidColorBrush _fieldThreeColor;
        private SolidColorBrush _fielFourColor;

        public ControlViewModel()
        {
            FieldOneColor = _defaultColor;
            FieldTwoColor = _defaultColor;
            FieldThreeColor = _defaultColor;
            FieldFourColor = _defaultColor;

            ButtonOneClick = new RelayCommand(ButtonOneClickExecute);
            ButtonOneDoubleClock = new RelayCommand(ButtonOneDoubleClickExecute);
            ButtonTwoClick = new RelayCommand(ButtonTwoClickExecute);
            ButtonTwoDoubleClick = new RelayCommand(ButtonTwoDoubleClickExecute);
        }
        
        public SolidColorBrush FieldOneColor
        {
            get => _fieldOneColor;
            set => OnPropertChanged(ref _fieldOneColor, value);
        }
        public SolidColorBrush FieldTwoColor
        {
            get => _fieldTwoColor;
            set => OnPropertChanged(ref _fieldTwoColor, value);
        }
        public SolidColorBrush FieldThreeColor
        {
            get => _fieldThreeColor;
            set => OnPropertChanged(ref _fieldThreeColor, value);
        }
        public SolidColorBrush FieldFourColor
        {
            get => _fielFourColor;
            set => OnPropertChanged(ref _fielFourColor, value);
        }

        public ICommand ButtonOneClick { get; set; }
        public ICommand ButtonOneDoubleClock { get; set; }
        public ICommand ButtonTwoClick { get; set; }
        public ICommand ButtonTwoDoubleClick { get; set; }

        private void ButtonOneClickExecute(object parameter)
        {
            FieldOneColor = FieldOneColor != null && FieldOneColor == _defaultColor ? _redColor : _defaultColor;
        }

        private void ButtonOneDoubleClickExecute(object parameter)
        {
            FieldTwoColor = FieldTwoColor != null && FieldTwoColor == _defaultColor ? _blueColor : _defaultColor;
        }

        private void ButtonTwoClickExecute(object parameter)
        {
            FieldThreeColor = FieldThreeColor != null && FieldThreeColor == _defaultColor ? _redColor : _defaultColor;
        }

        private void ButtonTwoDoubleClickExecute(object parameter)
        {
            FieldFourColor = FieldFourColor != null && FieldFourColor == _defaultColor ? _blueColor : _defaultColor;
        }
    }
}
