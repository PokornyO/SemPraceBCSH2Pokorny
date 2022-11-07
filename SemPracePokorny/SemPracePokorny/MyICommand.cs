using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SemPracePokorny
{
    internal class MyICommand : ICommand
    {
        Action TargetExecuteMethod;
        Func<bool> TargetCanExecuteMethod;

        public MyICommand(Action executeMethod)
        {
            TargetExecuteMethod = executeMethod;
        }

        public MyICommand(Action executeMethod, Func<bool> canExecuteMethod)
        {
            TargetExecuteMethod = executeMethod;
            TargetCanExecuteMethod = canExecuteMethod;
        }

        public void RaiseCanExecuteChanged()
        {
            CanExecuteChanged(this, EventArgs.Empty);
        }

        bool ICommand.CanExecute(object parameter)
        {

            if (TargetCanExecuteMethod != null)
            {
                return TargetCanExecuteMethod();
            }

            if (TargetExecuteMethod != null)
            {
                return true;
            }

            return false;
        }
        public event EventHandler CanExecuteChanged = delegate { };

        void ICommand.Execute(object parameter)
        {
            if (TargetExecuteMethod != null)
            {
                TargetExecuteMethod();
            }
        }
    }
}
