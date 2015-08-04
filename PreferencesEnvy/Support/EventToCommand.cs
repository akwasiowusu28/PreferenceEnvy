#region Using Directives
using System;
using System.Windows;
using System.Windows.Input;
using System.Windows.Interactivity;
#endregion

namespace PreferencesEnvy.Support
{
    public class EventToCommand : TriggerAction<DependencyObject>
    {
        #region Properties
        private bool? _IsDisabledWhenCantExecuteValue;
        public bool IsDisabledWhenCantExecuteValue
        {
            get
            {
                return _IsDisabledWhenCantExecuteValue == null ? IsDisabledWhenCantExecute : _IsDisabledWhenCantExecuteValue.Value;
            }

            set
            {
                _IsDisabledWhenCantExecuteValue = value;
                UpdateCanExecute();
            }
        }

        public bool PassEventArgsToCommand { get; set; }
        #endregion

        #region Dependency Properties
        public static readonly DependencyProperty CommandProperty =
            DependencyProperty.Register("Command", typeof(ICommand), typeof(EventToCommand), new PropertyMetadata(null, OnCommandChanged));

        public ICommand Command
        {
            get { return (ICommand)GetValue(CommandProperty); }
            set { SetValue(CommandProperty, value); }
        }

        private static void OnCommandChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EventToCommand eventToCommand = d as EventToCommand;
            if (eventToCommand != null)
            {
                if (e.OldValue != null)
                    ((ICommand)e.OldValue).CanExecuteChanged -= eventToCommand.OnCommandCanExecuteChanged;

                ICommand command = (ICommand)e.NewValue;
                if (command != null)
                    command.CanExecuteChanged += eventToCommand.OnCommandCanExecuteChanged;

                eventToCommand.UpdateCanExecute();
            }
        }

        public static readonly DependencyProperty CommandParameterProperty =
            DependencyProperty.Register("CommandParameter", typeof(object), typeof(EventToCommand), new PropertyMetadata(null, OnCommandParameterChanged));

        public object CommandParameter
        {
            get { return (object)GetValue(CommandParameterProperty); }
            set { SetValue(CommandParameterProperty, value); }
        }

        private static void OnCommandParameterChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EventToCommand eventToCommand = d as EventToCommand;
            if (eventToCommand != null && eventToCommand.AssociatedObject != null)
                eventToCommand.UpdateCanExecute();
        }

        public static readonly DependencyProperty IsDisabledWhenCantExecuteProperty =
            DependencyProperty.Register("IsDisabledWhenCantExecute", typeof(bool), typeof(EventToCommand), new PropertyMetadata(false, OnIsDisabledWhenCantExecuteChanged));

        public bool IsDisabledWhenCantExecute
        {
            get { return (bool)GetValue(IsDisabledWhenCantExecuteProperty); }
            set { SetValue(IsDisabledWhenCantExecuteProperty, value); }
        }

        private static void OnIsDisabledWhenCantExecuteChanged(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            EventToCommand eventToCommand = d as EventToCommand;
            if (eventToCommand != null && eventToCommand.AssociatedObject != null)
                eventToCommand.UpdateCanExecute();
        }
        #endregion

        #region Overrides
        protected override void OnAttached()
        {
            base.OnAttached();

            UpdateCanExecute();
        }

        protected override void Invoke(object parameter)
        {
            if (!IsFrameworkElementDisabled())
            {
                if (CommandParameter == null && PassEventArgsToCommand)
                    CommandParameter = parameter;

                if (Command != null && Command.CanExecute(CommandParameter))
                    Command.Execute(CommandParameter);
            }
        }
        #endregion

        #region Private
        private bool IsFrameworkElementDisabled()
        {
            FrameworkElement frameworkElement = AssociatedObject as FrameworkElement;
            return frameworkElement == null || (frameworkElement != null && !frameworkElement.IsEnabled);
        }

        private void UpdateCanExecute()
        {
            FrameworkElement frameworkElement = AssociatedObject as FrameworkElement;
            if (frameworkElement != null && Command != null && IsDisabledWhenCantExecuteValue)
                frameworkElement.IsEnabled = Command.CanExecute(CommandParameter);
        }
        #endregion

        #region Public
        public void Invoke()
        {
            Invoke(null);
        }
        #endregion

        #region Events
        private void OnCommandCanExecuteChanged(object sender, EventArgs e)
        {
            UpdateCanExecute();
        }
        #endregion
    }
}