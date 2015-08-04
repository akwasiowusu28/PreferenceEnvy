using System;
using System.Windows.Input;

namespace PreferencesEnvy.Support
{
    public class DelegateCommand : ICommand
    {
        #region Fields

        private readonly Action<Object> _execute;
        private readonly Predicate<Object> _canExecute;

        #endregion

        #region Events

        #endregion

        #region Methods

        #region Public

        public DelegateCommand(Action<object> execute, Predicate<object> canExecute)
        {
            _execute = execute;
            _canExecute = canExecute;
        }

        public DelegateCommand(Action<object> execute) : this(execute,null)
        {
        }

        public bool CanExecute(object parameter)
        {
            bool result = true;
            if (_canExecute != null)
            {
               result = _canExecute(parameter);
            }

            return result;
        }

        public void Execute(object parameter)
        {
            _execute(parameter);
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

        #endregion
    }
}
