using System;
using System.Windows.Input;
namespace PreferencesEnvy.Support
{
    public interface IDelegateCommand : ICommand
    {
        Predicate<object> CanExecuteAction { get; set; }
        Action<object> ExecuteAction { get; set; }
    }
}
