using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PreferencesEnvy.Support
{
    public class PreferenceType
    {
        public static readonly PreferenceType MarketPreferences = new PreferenceType("Market Preference");
        public static readonly PreferenceType ConfigPreferences = new PreferenceType("Configuration Preference");

        public static List<PreferenceType> Values
        {
            get
            {
                return new List<PreferenceType>
                {
                    MarketPreferences,
                    ConfigPreferences
                };
            }
        }
        private string _Name;


        private PreferenceType(string name)
        {
            _Name = name;
        }

        public override bool Equals(object obj)
        {
            return obj != null && ((PreferenceType)obj)._Name.Equals(_Name);
        }

        public override string ToString()
        {
            return _Name;
        }

        public override int GetHashCode()
        {
            return _Name.GetHashCode();
        }
    }
}
