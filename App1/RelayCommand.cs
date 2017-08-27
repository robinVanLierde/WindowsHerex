﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectWindows.View
{
    class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;
        

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, EventArgs.Empty);
        }

        private Action<object> execute;
        private Func<object, bool> canExecute;

        public RelayCommand(Action<object> action, Func<object, bool> test)
        {
            execute = action;
            canExecute = test;
        }



        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            execute(parameter);

        }
    }
}
