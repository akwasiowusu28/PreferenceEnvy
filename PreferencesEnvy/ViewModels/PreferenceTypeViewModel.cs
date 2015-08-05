using PreferencesEnvy.Support;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace PreferencesEnvy.ViewModels
{
    public class PreferenceTypeViewModel : ViewModelBase, IPreferenceTypeViewModel
    {
        private IWindowFactory _WindowFactory;

        public PreferenceTypeViewModel(IWindowFactory windowFactory, 
                                       IDelegateCommand selectedPrefenceCommand,
                                       IDelegateCommand openFileCommand, 
                                       IDelegateCommand cancelCommand)
        {
            _WindowFactory = windowFactory;

            openFileCommand.ExecuteAction = x => OpenFileDialog();
            selectedPrefenceCommand.ExecuteAction = p => SetSelectedPreferenceType(p);

            SelectedPreferenceTypeCommand = selectedPrefenceCommand;
            OpenFileDialogCommand = openFileCommand;

        }

        public string PreferenceFileName { get; set; }

        public ICommand OpenFileDialogCommand { get; set; }
        public ICommand CancelDialogCommand { get; set; }
        public ICommand SelectedPreferenceTypeCommand { get; set; }

        private PreferenceType _PrefFileType;
        public PreferenceType PrefFileType 
        {
            get { return _PrefFileType; }
            set 
            {
                _PrefFileType = value;
                NotifyPropertyChanged();
            } 
        }

        private void Cancel()
        {

        }

        private void OpenFileDialog()
        {
            PreferenceFileName = _WindowFactory.OpenFileDialog();
        }

        private void SetSelectedPreferenceType(object selectedValue)
        {
            PrefFileType = selectedValue as PreferenceType;
        }
    }
}
