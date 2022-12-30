using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Input;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NHL;
using StatsNHL.ViewModel;

namespace StatsNHL.Commands
{
    public class ButtonCommand : ICommand
    {
        ResultsViewModel _resultsViewModel;
        public ButtonCommand(ResultsViewModel viewModel)
        {
            _resultsViewModel = viewModel;
        }

        public bool CanExecute(object parameter)
        {
            String date;
            if (parameter != null)
            {
                date = parameter.ToString();
            } else
            {
                date = "";
            }

            date = add_zeros_if_missing(date);
            if(date.Length >= 8 && date.Length <= 10 && date.Substring(2,1) == "." && date.Substring(5,1) == "." && check_if_contains_only_two_dots(date))
            {
                if(month_no_more_thirteen(date.Substring(3,2)))
                {
                    if (Regex.IsMatch(date, @".*\\d.*") || Regex.IsMatch(date, @"."))
                    {
                        return true;
                    }
                    else
                    {
                        return false;
                    }
                }
                else
                {
                    return false;
                }
            } 
            else
            {
                return false;
            }
        }

        public void Execute(object parameter)
        {
            _resultsViewModel.OnExecute();
        }

        public event EventHandler CanExecuteChanged
        {
            add { CommandManager.RequerySuggested += value; }
            remove { CommandManager.RequerySuggested -= value; }
        }

        public void RaiseCanExecuteChanged()
        {
            CommandManager.InvalidateRequerySuggested();
        }

        private bool month_no_more_thirteen(String month)
        {
            int x;
            if (Convert.ToInt32(month[0]) == 0)
            {
                x = Convert.ToInt32(month[1]);
            }
            else
            {
                x = Convert.ToInt32(month);
            }

            if(x < 13)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        private String add_zeros_if_missing(String date)
        {
            if (date.Length == 8)
            {
                String date_with_two_new_zeros;
                date_with_two_new_zeros = "0" + date[0] + date[1] + "0" + date[2];

                for (int i = 3; i < 8; i++)
                {
                    date_with_two_new_zeros += date[i];
                }

                date = date_with_two_new_zeros;
            }

            if (date.Length == 9)
            {
                if (Char.Equals(date[1], '.'))
                {
                    String date_with_one_new_zero;
                    date_with_one_new_zero = "0";

                    for (int i = 0; i < 9; i++)
                    {
                        date_with_one_new_zero += date[i];
                    }

                    date = date_with_one_new_zero;

                }
                else if (Char.Equals(date[2], '.'))
                {
                    String date_with_one_new_zero = "";

                    for (int i = 0; i < 9; i++)
                    {
                        date_with_one_new_zero += date[i];

                        if (i == 2)
                        {
                            date_with_one_new_zero += "0";
                        }
                    }

                    date = date_with_one_new_zero;
                }
            }

            return date;
        }

        private bool check_if_contains_only_two_dots(String date)
        {
            bool ret = false;
            int count = 0;
            foreach (char a in date)
            {
                if (Char.Equals(a, '.'))
                    count++;
            }

            if(count == 2)
            {
                ret = true;
            }
            else
            {
                ret = false;
            }
            return ret;
        }
    }
}
