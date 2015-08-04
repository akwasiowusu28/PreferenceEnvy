using System.Collections.ObjectModel;
using System.Windows.Input;
namespace PreferencesEnvy.ViewModels
{
    public interface IMainViewModel
    {
        void Initialize();
        ObservableCollection<IPreferenceViewModel> Preferences { get; set; }
        ICommand SaveAllCommand { get; set; }
        ICommand SavePreferenceCommand { get; set; }
        ICommand SelectedPreferenceCommand { get; set; }
        IPreferenceViewModel SelectedPreference { get; set; }
    }
}
