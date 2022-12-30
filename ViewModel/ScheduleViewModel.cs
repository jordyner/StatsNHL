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
using System.IO;
using System.ComponentModel;
using System.Windows.Data;
using System.Collections.ObjectModel;

namespace StatsNHL.ViewModel
{
    public class ScheduleViewModel : MainViewModel
    {
        private ObservableCollection<Match> MatchInfo;
        private CollectionViewSource MatchInfoCollection;
        public ICollectionView SourceCollection => MatchInfoCollection.View;

        private string _filterTeamName;

        public ScheduleViewModel()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            MatchInfo = new ObservableCollection<Match>();

            for(int i = 1; i <= 4; i++)
            {
                string addedDate = DateTime.Now.Date.AddDays(i).ToString("yyyy.MM.dd");
                foreach (var game in GetAllGamesByDate(addedDate))
                {
                    String[] key_to_name_home = new String[2];
                    String[] key_to_name_away = new String[2];
                    key_to_name_home = fullName(game.HomeTeam);
                    key_to_name_away = fullName(game.AwayTeam);
                    BoxScore score = GetBoxScore(game.GameID);
                    String date = game.DateTime.ToString();

                    MatchInfo.Add(new Match()
                    {
                        HomeTeam = new TeamInfo() { FullName = key_to_name_home[0] + " " + key_to_name_home[1], LogoPath = @"\Images\Logos\" + key_to_name_home[1] + ".png" },
                        AwayTeam = new TeamInfo() { FullName = key_to_name_away[0] + " " + key_to_name_away[1], LogoPath = @"\Images\Logos\" + key_to_name_away[1] + ".png" },
                        Date = date.Replace("/", ".")
                    });
                }
            }
            MatchInfoCollection = new CollectionViewSource { Source = MatchInfo };
            MatchInfoCollection.Filter += TeamNameFilter;
        }
        public string FilterTeamName
        {
            get => _filterTeamName;
            set
            {
                _filterTeamName = value;
                MatchInfoCollection.View.Refresh();
                OnPropertyChanged("FilterTeamName");
            }
        }

        private void TeamNameFilter(object sender, FilterEventArgs e)
        {
            Match _item = e.Item as Match;
            if (!string.IsNullOrEmpty(FilterTeamName))
            {
                if (_item.HomeTeam.FullName.ToUpper().Contains(FilterTeamName.ToUpper()) || _item.AwayTeam.FullName.ToUpper().Contains(FilterTeamName.ToUpper()))
                {
                    e.Accepted = true;
                }
                else
                {
                    e.Accepted = false;
                }
            }
        }
    }
}
