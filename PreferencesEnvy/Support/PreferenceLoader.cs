using Core.Entities;
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
        private readonly Container _Container;
        private readonly ISerializerService _SerializerService;
        private PrefFile _PrefFile;

        public PreferencesManager(ISerializerService serializerService, Container container){
            _Container = container;
            _SerializerService = serializerService;
        }

        public List<IPreferenceViewModel> LoadedPreferences()
        {
            List<IPreferenceViewModel> preferenceViewModels = new List<IPreferenceViewModel>();

            _PrefFile = _SerializerService.Deserialize<PrefFile>("C:/Users/aowusu/Desktop/preferences.pref"); //TODO: refactor this
            foreach (var preference in _PrefFile.Preferences.Prefs)
            {
                IPreferenceViewModel preferenceViewModel = _Container.GetInstance<IPreferenceViewModel>();
                preferenceViewModel.Preference = preference;
                preferenceViewModel.CurrentPreferenceValue = getcurrentValue(preference);

                preferenceViewModels.Add(preferenceViewModel);
            }
            return preferenceViewModels;
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

        public void SavePreference(IPreferenceViewModel newValue)
        {
            if (newValue != null)
            {
                Preference pref = _PrefFile.Preferences.Prefs.Where((p) => p.ID.Equals(newValue.Preference.ID)).FirstOrDefault();
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
            _SerializerService.Serialize<PrefFile>("C:/Users/aowusu/Desktop/preferences.pref", _PrefFile); //TODO: Refactor this
        }
    }
}
