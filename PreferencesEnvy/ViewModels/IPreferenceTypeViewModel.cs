using PreferencesEnvy.Support;
using System;
using System.Windows.Input;
namespace PreferencesEnvy.ViewModels
{
    public interface IPreferenceTypeViewModel
    {
        ICommand CancelDialogCommand { get; set; }
        ICommand OpenFileDialogCommand { get; set; }
        ICommand SelectedPreferenceTypeCommand { get; set; }
        string PreferenceFileName { get; set; }
        PreferenceType PrefFileType { get; set; }
    }
}
