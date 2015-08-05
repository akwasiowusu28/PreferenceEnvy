using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferencesEnvy.ViewModels
{
    public class PreferenceViewModel : ViewModelBase, IPreferenceViewModel
    {
        private bool _IsDirty;
        public bool IsDirty
        {
            get { return _IsDirty; }
            set
            {
                _IsDirty = value;
                NotifyPropertyChanged();

            }
        }

        private IPreference _Preference;
        public IPreference Preference
        {
            get { return _Preference; }
            set
            {
                _Preference = value;
                NotifyPropertyChanged();
            }
        }

        private IValue _CurrentPreferenceValue;
        public IValue CurrentPreferenceValue
        {
            get { return _CurrentPreferenceValue; }
            set
            {
                _CurrentPreferenceValue = value;
                if (_Preference != null && _CurrentPreferenceValue != null)
                {
                    _Preference.DefaultValue = _CurrentPreferenceValue.ID;
                    NotifyPropertyChanged("Preference");
                }
                NotifyPropertyChanged();
            }
        }
    }
}
