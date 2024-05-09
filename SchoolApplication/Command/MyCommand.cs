using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace SchoolApplication.Command
{
    public class MyCommand :ICommand
    {
        public event EventHandler CanExecuteChanged;

        Action<object> execute;  
        Predicate<object> canExecute; 


       
        public MyCommand(Predicate<object> _canExecute, Action<object> _execute)
        {
            execute = _execute;
            canExecute = _canExecute;
        }

        public bool CanExecute(object parameter)
        {
            
            return canExecute == null ? true : canExecute(parameter);
        }

        public void Execute(object parameter)
        {
            execute(parameter);
        }




    }
}
