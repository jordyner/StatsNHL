using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyData.Api.Client;
using FantasyData.Api.Client.Model.NHL;
using System.Web.Configuration;
using System.Net;
using StatsNHL.Model;
using StatsNHL.Commands;
using System.IO;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;
using System.Windows;
using System.Windows.Input;

namespace StatsNHL.ViewModel
{
    public class ResultsViewModel : MainViewModel
    {
        public ButtonCommand ButtonCommand { get; set; }

        private ObservableCollection<Match> MatchInfo;
        private CollectionViewSource MatchInfoCollection;
        public ICollectionView SourceCollection => MatchInfoCollection.View;

        private string _dateToAdd;

        public ResultsViewModel()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            ButtonCommand = new ButtonCommand(this);

            MatchInfo = new ObservableCollection<Match>();

            foreach (var game in GetAllGamesByDate(DateTime.Today.AddDays(-1).ToString("yyyy.MM.dd")))
            {
                String[] key_to_name_home = new String[2];
                String[] key_to_name_away = new String[2];
                key_to_name_home = fullName(game.HomeTeam);
                key_to_name_away = fullName(game.AwayTeam);
                BoxScore score = GetBoxScore(game.GameID);
                String date = game.DateTime.ToString();
                int homeGoals, awayGoals;
                if (score.Game.HomeTeamScore.HasValue) homeGoals = score.Game.HomeTeamScore.Value; else homeGoals = 0;
                if (score.Game.AwayTeamScore.HasValue) awayGoals = score.Game.AwayTeamScore.Value; else awayGoals = 0;

                MatchInfo.Add(new Match()
                {
                    HomeTeam = new TeamInfo() { FullName = key_to_name_home[0] + " " + key_to_name_home[1], LogoPath = @"\Images\Logos\" + key_to_name_home[1] + ".png" },
                    AwayTeam = new TeamInfo() { FullName = key_to_name_away[0] + " " + key_to_name_away[1], LogoPath = @"\Images\Logos\" + key_to_name_away[1] + ".png" },
                    HomeScore = homeGoals,
                    AwayScore = awayGoals,
                    Date = (date)
                });
            }

            MatchInfoCollection = new CollectionViewSource { Source = MatchInfo };
        }

        public string DateToAdd
        {
            get => _dateToAdd;
            set
            {
                _dateToAdd = value;
                ButtonCommand.RaiseCanExecuteChanged();
                OnPropertyChanged("DateToAdd");
            }
        }

        public void OnExecute()
        {
            MatchInfo.Clear();

            foreach (var game in GetAllGamesByDate(swap_month_day(DateToAdd)))
            {
                String[] key_to_name_home = new String[2];
                String[] key_to_name_away = new String[2];
                key_to_name_home = fullName(game.HomeTeam);
                key_to_name_away = fullName(game.AwayTeam);
                BoxScore score = GetBoxScore(game.GameID);
                String date = game.DateTime.ToString();
                int homeGoals, awayGoals;
                if (score.Game.HomeTeamScore.HasValue) homeGoals = score.Game.HomeTeamScore.Value; else homeGoals = 0;
                if (score.Game.AwayTeamScore.HasValue) awayGoals = score.Game.AwayTeamScore.Value; else awayGoals = 0;

                MatchInfo.Add(new Match()
                {
                    HomeTeam = new TeamInfo() { FullName = key_to_name_home[0] + " " + key_to_name_home[1], LogoPath = @"\Images\Logos\" + key_to_name_home[1] + ".png" },
                    AwayTeam = new TeamInfo() { FullName = key_to_name_away[0] + " " + key_to_name_away[1], LogoPath = @"\Images\Logos\" + key_to_name_away[1] + ".png" },
                    HomeScore = homeGoals,
                    AwayScore = awayGoals,
                    Date = swap_month_day(date)
                });
            }
        }

        private String swap_month_day(String date)
        {
            String swapped_month_and_day = date.Substring(3, 2) + date.Substring(2, 1) + date.Substring(0, 2) + date.Substring(5, 1) + date.Substring(6, 4);
            return swapped_month_and_day;
        }

    }
}
