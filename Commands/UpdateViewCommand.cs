using StatsNHL.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace StatsNHL.Commands
{
    public class UpdateViewCommand : ICommand
    {
        private MainViewModel viewModel;
        private BaseViewModel selectedViewModel;

        public UpdateViewCommand(MainViewModel viewModel)
        {
            this.viewModel = viewModel;
        }

        public UpdateViewCommand(BaseViewModel selectedViewModel)
        {
            this.selectedViewModel = selectedViewModel;
        }

        public event EventHandler CanExecuteChanged;

        public bool CanExecute(object parameter)
        {
            if(parameter.ToString() == "News")
            {
                viewModel.SelectedViewModel = new NewsViewModel();

            }
            return true;
        }

        public void Execute(object parameter)
        {
            if(parameter.ToString() == "Standings")
            {
                viewModel.SelectedViewModel = new StandingsViewModel();
            } else if (parameter.ToString() == "Schedule")
            {
                viewModel.SelectedViewModel = new ScheduleViewModel();
            }
            else if (parameter.ToString() == "Results")
            {
                viewModel.SelectedViewModel = new ResultsViewModel();
            }

        }
    }
}
