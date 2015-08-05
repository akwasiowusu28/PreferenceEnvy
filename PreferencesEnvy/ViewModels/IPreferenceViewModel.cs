using Entities;
using System;
namespace PreferencesEnvy.ViewModels
{
    public interface IPreferenceViewModel
    {
        IValue CurrentPreferenceValue { get; set; }
        bool IsDirty { get; set; }
        IPreference Preference { get; set; }
    }
}
