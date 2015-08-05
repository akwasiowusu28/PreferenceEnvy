using PreferencesEnvy.ViewModels;
using System;
using System.Collections.Generic;
namespace PreferencesEnvy.Support
{
    public interface IPreferencesManager
    {
        List<IPreferenceViewModel> LoadedPreferences(PreferenceType preferenceType, string fileName);
        void SaveAll();
        void SavePreference(IPreferenceViewModel newValue);
    }
}
