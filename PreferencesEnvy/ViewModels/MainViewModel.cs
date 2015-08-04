using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.SerializerService;
using Core.Entities;
using PreferencesEnvy.Support;
using System.Windows.Input;

namespace PreferencesEnvy.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        #region Private fields and Contants

        private IPreferencesManager _PreferencesManager;
        private PrefFile _PrefFile;
        #endregion

        #region Constructors

        public MainViewModel(IPreferencesManager preferencesManager)
            : base()
        {
            _PreferencesManager = preferencesManager;

            //TODO: Find a way to inject these
            SelectedPreferenceCommand = new DelegateCommand(p => SetSelectedPreference(p)); 
            SavePreferenceCommand = new DelegateCommand(p => SavePreference(p));
            SaveAllCommand = new DelegateCommand(x => SaveAll());
        }

        #endregion

        #region Properties

        public ObservableCollection<IPreferenceViewModel> Preferences { get; set; }

        private IPreferenceViewModel _SelectedPreference;
        public IPreferenceViewModel SelectedPreference
        {
            get { return _SelectedPreference; }
            set
            {
                _SelectedPreference = value;
                NotifyPropertyChanged();
            }
        }

        public ICommand SelectedPreferenceCommand { get; set; }
        public ICommand SavePreferenceCommand { get; set; }
        public ICommand SaveAllCommand { get; set; }
        #endregion

        #region Public Methods

        public void Initialize()
        {
            Preferences = new ObservableCollection<IPreferenceViewModel>(_PreferencesManager.LoadedPreferences());
        }

        #endregion

        #region Private Methods 

        private void SetSelectedPreference(object preference)
        {
            SelectedPreference = preference as PreferenceViewModel;
        }

        private void SavePreference(object newValue)
        {
            var selectedValue = newValue as PreferenceViewModel;
            _PreferencesManager.SavePreference(selectedValue);
        }

        private void SaveAll()
        {
            
        }
        #endregion
    }
}
