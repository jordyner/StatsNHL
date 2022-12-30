using StatsNHL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatsNHL.Commands
{
    public class ChangeStandingsCommand : ICommand
    {
        public event EventHandler CanExecuteChanged;

        StandingsViewModel _standingsViewModel;
        public ChangeStandingsCommand(StandingsViewModel viewModel)
        {
            _standingsViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            return true;
        }

        public void Execute(object parameter)
        {
            _standingsViewModel.OnExecute(parameter.ToString());
        }
    }
}
