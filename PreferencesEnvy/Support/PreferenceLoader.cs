using Entities;
using Core.SerializerService;
using PreferencesEnvy.ViewModels;
using SimpleInjector;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferencesEnvy.Support
{
    public class PreferencesManager : IPreferencesManager
    {
        #region Private fields

        private readonly Container _Container;
        private readonly ISerializerService _SerializerService;
        private ConfigPrefFile _ConfigPrefFile;
        private MarketPrefFile _MarketPrefFile;
        private string _FileName;
        private PreferenceType _PreferenceType;

        #endregion
        
        #region Constructor

        public PreferencesManager(ISerializerService serializerService, Container container){
            _Container = container;
            _SerializerService = serializerService;
        }

        #endregion

        #region Public Methods
        public List<IPreferenceViewModel> LoadedPreferences(PreferenceType preferenceType, string fileName)
        {
            List<IPreferenceViewModel> preferenceViewModels = new List<IPreferenceViewModel>();
           
            _FileName = fileName;
            _PreferenceType = preferenceType;

            IPrefFile prefFile = GetPreferenceFile();
            
            foreach (var preference in prefFile.Preferences.Prefs)
            {
                IPreferenceViewModel preferenceViewModel = _Container.GetInstance<IPreferenceViewModel>();
                preferenceViewModel.Preference = preference;
                preferenceViewModel.CurrentPreferenceValue = getcurrentValue(preference);

                preferenceViewModels.Add(preferenceViewModel);
            }
            return preferenceViewModels;
        }

        public void SavePreference(IPreferenceViewModel newValue)
        {
            if (newValue != null)
            {
                IPreference pref = _ConfigPrefFile.Preferences.Prefs.Where((p) => p.ID.Equals(newValue.Preference.ID)).FirstOrDefault();
                if (pref != null)
                {
                    if (newValue.CurrentPreferenceValue != null)
                    {
                        pref.DefaultValue = newValue.CurrentPreferenceValue.ID;
                    }
                    else
                    {
                        pref.DefaultValue = newValue.Preference.DefaultValue;
                    }
                }
            }
        }

        public void SaveAll()
        {
            if (_PreferenceType.Equals(PreferenceType.ConfigPreferences))
            {
                _SerializerService.Serialize<ConfigPrefFile>(_FileName, _ConfigPrefFile); 
            }
            else
            {
                _SerializerService.Serialize<MarketPrefFile>(_FileName, _MarketPrefFile);
            }
        }
        #endregion

        #region Private Methods
        private IPrefFile GetPreferenceFile()
        {
            IPrefFile prefFile = null;
            if (_PreferenceType.Equals(PreferenceType.ConfigPreferences))
            {
                _ConfigPrefFile = _SerializerService.Deserialize<ConfigPrefFile>(_FileName);
                prefFile = _ConfigPrefFile;
            }
            else
            {
                _MarketPrefFile = _SerializerService.Deserialize<MarketPrefFile>(_FileName);
                prefFile = _MarketPrefFile;
            }
            return prefFile;
        }

        private IValue getcurrentValue(IPreference preference)
        {
             IValue currentValue = null;
            if (preference != null && preference.Values != null && preference.Values.Any())
            {
                currentValue = _Container.GetInstance<IValue>();
                currentValue.ID = preference.DefaultValue;
                currentValue.Name = preference.Values.FirstOrDefault(v => v.ID.Equals(preference.DefaultValue));
            }

            return currentValue;
        }

        #endregion


        
    }
}
