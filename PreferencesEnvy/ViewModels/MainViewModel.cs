using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.ObjectModel;
using Core.SerializerService;
using Entities;
using PreferencesEnvy.Support;
using System.Windows.Input;
using System.Windows;

namespace PreferencesEnvy.ViewModels
{
    public class MainViewModel : ViewModelBase, IMainViewModel
    {
        #region Private fields and Contants

        private IPreferencesManager _PreferencesManager;
        private IWindowFactory _WindowFactory;
        private IPreferenceTypeViewModel _PreferenceTypeViewModel;

        #endregion

        #region Constructors

        public MainViewModel(IPreferencesManager preferencesManager, 
                             IWindowFactory windowFactory, 
                             IDelegateCommand selectedPreferenceCommand, 
                             IDelegateCommand savePreferenceCommand,
                             IDelegateCommand saveAllCommand,
                             IDelegateCommand openFileCommand,
                             IPreferenceTypeViewModel preferenceTypeViewModel)
            : base()
        {
            _PreferencesManager = preferencesManager;
            _WindowFactory = windowFactory;
            _PreferenceTypeViewModel = preferenceTypeViewModel;

            selectedPreferenceCommand.ExecuteAction = p => SetSelectedPreference(p);
            savePreferenceCommand.ExecuteAction = p => SavePreference(p);
            saveAllCommand.ExecuteAction = p => SaveAll();
            openFileCommand.ExecuteAction = p => OpenFile();

            SelectedPreferenceCommand = selectedPreferenceCommand;
            SavePreferenceCommand = savePreferenceCommand;
            SaveAllCommand = saveAllCommand;
            OpenFileCommand = openFileCommand;

            Preferences = new ObservableCollection<IPreferenceViewModel>();
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
        public ICommand OpenFileCommand { get; set; }

        private PreferenceType _PreferenceType;
        public PreferenceType PreferenceType
        {
            get { return _PreferenceType; }
            set
            {
                _PreferenceType = value;
                NotifyPropertyChanged();
            }
        }

        #endregion

        #region Public Methods

        public void Initialize()
        {
           // Preferences = new ObservableCollection<IPreferenceViewModel>(_PreferencesManager.LoadedPreferences());
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
      //      _PreferencesManager.SaveAll();
        }

        private void OpenFile()
        {
            try
            {
                _WindowFactory.OpenPreferenceFileDialog(_PreferenceTypeViewModel);
                string fileName = _PreferenceTypeViewModel.PreferenceFileName;
                PreferenceType preferenceType = _PreferenceTypeViewModel.PrefFileType;
                List<IPreferenceViewModel> prefs = _PreferencesManager.LoadedPreferences(preferenceType, fileName);
                Preferences.Clear();
                foreach (var pref in prefs)
                {
                    Preferences.Add(pref);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("You selected a file different than the type specified", "Wrong file"); //Move this elsewhere
            }
            
        }
        #endregion
    }
}
