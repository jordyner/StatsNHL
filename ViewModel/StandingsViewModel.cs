using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FantasyData.Api.Client.Model.NHL;
using FantasyData.Api.Client;
using System.Web.Configuration;
using System.Net;
using StatsNHL.Model;
using StatsNHL.Commands;
using System.IO;

namespace StatsNHL.ViewModel
{
    public class StandingsViewModel : MainViewModel
    {
        public List<TeamInfo> _metropolitan;
        public List<TeamInfo> _pacific;
        public List<TeamInfo> _central;
        public List<TeamInfo> _atlantic;

        private List<TeamInfo> All_Teams_Pacific;
        private List<TeamInfo> All_Teams_Atlantic;
        private List<TeamInfo> All_Teams_Metropolitan;
        private List<TeamInfo> All_Teams_Central;

        public List<TeamInfo> _eastern;
        public List<TeamInfo> _western;

        private List<TeamInfo> All_Teams_Eastern;
        private List<TeamInfo> All_Teams_Western;

        public String _visibilityDiv;
        public String _visibilityConf;

        public ChangeStandingsCommand ChangeStandingsCommand { get; set; }

        public StandingsViewModel()
        {
            ChangeStandingsCommand = new ChangeStandingsCommand(this);

            _visibilityDiv = "Visible";
            _visibilityConf = "Hidden";

            All_Teams_Pacific = new List<TeamInfo>();
            All_Teams_Atlantic = new List<TeamInfo>();
            All_Teams_Metropolitan = new List<TeamInfo>();
            All_Teams_Central = new List<TeamInfo>();

            foreach (var team in GetAllTeams())
            {
                int points = ((team.Wins) * 2 + (team.OvertimeLosses)).Value;
                String logo = @"\Images\Logos\" + team.Name + ".png";

                if (team.Division == "Pacific")
                {
                    All_Teams_Pacific.Add(new TeamInfo(points, team.City + " " + team.Name, logo));
                }
                else if (team.Division == "Atlantic")
                {
                    All_Teams_Atlantic.Add(new TeamInfo(points, team.City + " " + team.Name, logo));
                }
                else if (team.Division == "Metropolitan")
                {
                    All_Teams_Metropolitan.Add(new TeamInfo(points, team.City + " " + team.Name, logo));
                }
                else if (team.Division == "Central")
                {
                    All_Teams_Central.Add(new TeamInfo(points, team.City + " " + team.Name, logo));
                }
            }

            All_Teams_Eastern = new List<TeamInfo>();
            All_Teams_Western = new List<TeamInfo>();
            foreach (var team in GetAllTeams())
            {
                int points = ((team.Wins) * 2 + (team.OvertimeLosses)).Value;
                String logo = @"\Images\Logos\" + team.Name + ".png";

                if (team.Conference == "Eastern")
                {
                    All_Teams_Eastern.Add(new TeamInfo(points, team.City + " " + team.Name, logo));
                }
                else if (team.Conference == "Western")
                {
                    All_Teams_Western.Add(new TeamInfo(points, team.City + " " + team.Name, logo));
                }
            }

            sort_teams(All_Teams_Eastern);
            sort_teams(All_Teams_Western);
            sort_teams(All_Teams_Pacific);
            sort_teams(All_Teams_Central);
            sort_teams(All_Teams_Metropolitan);
            sort_teams(All_Teams_Atlantic);
            fill_lb_with_data();
        }

        public void OnExecute(String listbox)
        {
            if (listbox == "Conf")
            {
                _visibilityDiv = "Hidden";
                _visibilityConf = "Visible";
                OnPropertyChanged("VisibilityDiv");
                OnPropertyChanged("VisibilityConf");
            }

            if(listbox == "Div")
            {
                _visibilityConf = "Hidden";
                _visibilityDiv = "Visible";
                OnPropertyChanged("VisibilityDiv");
                OnPropertyChanged("VisibilityConf");
            }
        }

        private void sort_teams(List<TeamInfo> teams_in_division)
        {
            int temp = 0;
            String name = "";
            String logo = "";
            for (int i = 0; i < teams_in_division.Count; i++)
            {
                for (int j = 0; j < teams_in_division.Count - 1; j++)
                {
                    if (teams_in_division[j].Points > teams_in_division[j + 1].Points)
                    {
                        name = teams_in_division[j + 1].FullName;
                        logo = teams_in_division[j + 1].LogoPath;
                        temp = teams_in_division[j + 1].Points;
                        teams_in_division[j + 1].Points = teams_in_division[j].Points;
                        teams_in_division[j + 1].FullName = teams_in_division[j].FullName;
                        teams_in_division[j + 1].LogoPath = teams_in_division[j].LogoPath;
                        teams_in_division[j].Points = temp;
                        teams_in_division[j].FullName = name;
                        teams_in_division[j].LogoPath = logo;
                    }
                }
            }
        }

        private void fill_lb_with_data()
        {
            _metropolitan = new List<TeamInfo>();
            _pacific = new List<TeamInfo>();
            _atlantic = new List<TeamInfo>();
            _central = new List<TeamInfo>();

            for (int i = All_Teams_Pacific.Count - 1; i >= 0; i--)
            {
                _pacific.Add(new TeamInfo()
                {
                    Points = All_Teams_Pacific[i].Points,
                    FullName = All_Teams_Pacific[i].FullName,
                    LogoPath = All_Teams_Pacific[i].LogoPath,
                });
            }

            for (int i = All_Teams_Central.Count - 1; i >= 0; i--)
            {
                _central.Add(new TeamInfo()
                {
                    Points = All_Teams_Central[i].Points,
                    FullName = All_Teams_Central[i].FullName,
                    LogoPath = All_Teams_Central[i].LogoPath,
                });
            }

            for (int i = All_Teams_Metropolitan.Count - 1; i >= 0; i--)
            {
                _metropolitan.Add(new TeamInfo()
                {
                    Points = All_Teams_Metropolitan[i].Points,
                    FullName = All_Teams_Metropolitan[i].FullName,
                    LogoPath = All_Teams_Metropolitan[i].LogoPath,
                });
            }

            for (int i = All_Teams_Atlantic.Count - 1; i >= 0; i--)
            {
                _atlantic.Add(new TeamInfo()
                {
                    Points = All_Teams_Atlantic[i].Points,
                    FullName = All_Teams_Atlantic[i].FullName,
                    LogoPath = All_Teams_Atlantic[i].LogoPath,
                });
            }

            _eastern = new List<TeamInfo>();
            _western = new List<TeamInfo>();

            for (int i = All_Teams_Eastern.Count - 1; i >= 0; i--)
            {
                _eastern.Add(new TeamInfo()
                {
                    Points = All_Teams_Eastern[i].Points,
                    FullName = All_Teams_Eastern[i].FullName,
                    LogoPath = All_Teams_Eastern[i].LogoPath
                });
            }

            for (int i = All_Teams_Western.Count - 1; i >= 0; i--)
            {
                _western.Add(new TeamInfo()
                {
                    Points = All_Teams_Western[i].Points,
                    FullName = All_Teams_Western[i].FullName,
                    LogoPath = All_Teams_Western[i].LogoPath
                });
            }
        }

        public List<TeamInfo> Metropolitan { get { return _metropolitan; } set { _metropolitan = value; OnPropertyChanged(nameof(SelectedViewModel)); } }
        public List<TeamInfo> Pacific { get { return _pacific; } set { _pacific = value; OnPropertyChanged(nameof(SelectedViewModel)); } }
        public List<TeamInfo> Central { get { return _central; } set { _central = value; OnPropertyChanged(nameof(SelectedViewModel)); } }
        public List<TeamInfo> Atlantic { get { return _atlantic; } set { _atlantic = value; OnPropertyChanged(nameof(SelectedViewModel)); } }
        public List<TeamInfo> Eastern { get { return _eastern; } set { _eastern = value; OnPropertyChanged(nameof(SelectedViewModel)); } }
        public List<TeamInfo> Western { get { return _western; } set { _western = value; OnPropertyChanged(nameof(SelectedViewModel)); } }

        public String VisibilityDiv { get { return _visibilityDiv; } set { _visibilityDiv = value; OnPropertyChanged(nameof(SelectedViewModel)); } }
        public String VisibilityConf { get { return _visibilityConf; } set { _visibilityConf = value; OnPropertyChanged(nameof(SelectedViewModel)); } }

    }
}
