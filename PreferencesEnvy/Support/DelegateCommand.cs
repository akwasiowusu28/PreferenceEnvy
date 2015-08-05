using System;
using System.Windows.Input;

namespace PreferencesEnvy.Support
{
    public class DelegateCommand : IDelegateCommand
    {
        
        
        #region Public

        public Action<Object> ExecuteAction { get; set; }
        public Predicate<Object> CanExecuteAction { get; set; }
        
        public bool CanExecute(object parameter)
        {
            bool result = true;
            if (CanExecuteAction != null)
            {
                result = CanExecuteAction(parameter);
            }

            return result;
        }

        public void Execute(object parameter)
        {
            if (ExecuteAction != null)
            {
                ExecuteAction(parameter);
            }
        }

        public event EventHandler CanExecuteChanged
        {
            add
            {
                CommandManager.RequerySuggested += value;
            }
            remove
            {
                CommandManager.RequerySuggested -= value;
            }
        }
        #endregion
    }
}
