using System.Collections.Generic;
using Common.CommonControls.ViewModels;

namespace Plugins.DropDown
{
    public class ControlViewModel : BaseViewModels
    {
        private string _textBoxValue;
        private string _selectedItem;

        public ControlViewModel()
        {
            ComboBoxContent = new[]
            {
                "123456789",
                "321654987",
                "000000000"
            };
        }

        public string TextBoxValue
        {
           get => _textBoxValue;
           set => OnPropertChanged(ref _textBoxValue, value);
        }

        public IEnumerable<string> ComboBoxContent 
        { 
            get; 
            set;
        }

        public string SelectedItem
        {
            get => _selectedItem;
            set
            {
                OnPropertChanged(ref _selectedItem, value);
                TextBoxValue = _selectedItem;
            }
        }
    }
}