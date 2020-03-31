using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;

namespace ToDo_WPF.Utils
{ 
        public class RelayCommand : ICommand
        {
            public event EventHandler CanExecuteChanged;

            private readonly Action _execute;

            private readonly Func<bool> _canExecute;

            public RelayCommand(Action execute, Func<bool> canExecute = null)
            {
                _execute = (!(execute is null)) ? execute : throw new InvalidOperationException();
                _canExecute = canExecute;
            }

            public bool CanExecute(object parameter)
            {
                return (_canExecute is null) ? true : _canExecute();
            }

            public void Execute(object parameter)
            {
                _execute();
            }

            internal void RaiseCanExecuteChanged()
            {
                CanExecuteChanged?.Invoke(this, EventArgs.Empty);
            }
        }
}
