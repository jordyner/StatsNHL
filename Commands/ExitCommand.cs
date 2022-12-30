using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatsNHL.Commands
{
    public class ExitCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        public ExitCommand()
        {
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            System.Windows.Application.Current.Shutdown();
        }
    }
}
