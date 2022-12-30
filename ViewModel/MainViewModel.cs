using StatsNHL.Commands;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using FantasyData.Api.Client.Model.NHL;
using FantasyData.Api.Client;
using System.Web.Configuration;
using System.Net;
using StatsNHL.Model;
using System.IO;
using System.Collections.ObjectModel;

namespace StatsNHL.ViewModel
{
    public class MainViewModel : BaseViewModel
    {
        private BaseViewModel _selectedViewModel;

        public BaseViewModel SelectedViewModel
        {
            get {
                return _selectedViewModel; }
            set {
                _selectedViewModel = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public List<Standing> GetAllTeams()
        {
            NHLv3StatsClient client = new NHLv3StatsClient(SportDataKey);
            return client.GetStandings("2022");
        }

        public List<Game> GetAllGames()
        {
            NHLv3StatsClient client = new NHLv3StatsClient(SportDataKey);
            return client.GetGames("2022");
        }

        public List<Game> GetAllGamesByDate(String date)
        {
            NHLv3StatsClient client = new NHLv3StatsClient(SportDataKey);
            return client.GetGamesByDate(date.Replace(".","-"));
        }

        public BoxScore GetBoxScore(int id)
        {
            NHLv3StatsClient client = new NHLv3StatsClient(SportDataKey);
            return client.GetBoxScore(id);
        }

        public List<News> GetNews()
        {
            NHLv3StatsClient client = new NHLv3StatsClient(SportDataKey);
            return client.GetNews();
        }


        private readonly string SportDataKey = WebConfigurationManager.AppSettings["SportDataKey"];

        public ICommand _updateViewCommand;
        public ICommand _exitCommand;
        public ICommand UpdateViewCommand
        {
            get
            {
                return _updateViewCommand;
            }
            set
            {
                _updateViewCommand = value;
                OnPropertyChanged(nameof(SelectedViewModel));
            }
        }

        public ICommand ExitCommand
        {
            get
            {
                return _exitCommand;
            }
            set
            {
                _exitCommand = value;
            }
        }

        public MainViewModel()
        {
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            UpdateViewCommand = new UpdateViewCommand(this);
            ExitCommand = new ExitCommand();
        }

        public String[] fullName(String key)
        {
            String[] ret = new string[2];
            if (key == "FLA")
            {
                ret[0] = "Florida";
                ret[1] = "Panthers";
                return ret;
            }
            else if (key == "PIT")
            {
                ret[0] = "Pittsburgh";
                ret[1] = "Penguins";
                return ret;
            }
            else if (key == "VAN")
            {
                ret[0] = "Vancouver";
                ret[1] = "Canucks";
                return ret;
            }
            else if (key == "MIN")
            {
                ret[0] = "Minnesota";
                ret[1] = "Wild";
                return ret; 
            }
            else if (key == "EDM")
            {
                ret[0] = "Edmonton";
                ret[1] = "Oilers";
                return ret;
            }
            else if (key == "CHI")
            {
                ret[0] = "Chicago";
                ret[1] = "Blackhawks";
                return ret;
            }
            else if (key == "MON")
            {
                ret[0] = "Montreal";
                ret[1] = "Canadiens";
                return ret;
            }
            else if (key == "TB")
            {
                ret[0] = "Tampa Bay";
                ret[1] = "Lightning";
                return ret;
            }
            else if (key == "NYR")
            {
                ret[0] = "New York";
                ret[1] = "Rangers";
                return ret;
            }
            else if (key == "CAR")
            {
                ret[0] = "Carolina";
                ret[1] = "Hurricanes";
                return ret;
            }
            else if (key == "DET")
            {
                ret[0] = "Detroit";
                ret[1] = "Red Wings";
                return ret;
            }
            else if (key == "COL")
            {
                ret[0] = "Colorado";
                ret[1] = "Avalanche";
                return ret;
            }
            else if (key == "NYI")
            {
                ret[0] = "New York";
                ret[1] = "Islanders";
                return ret;
            }
            else if (key == "OTT")
            {
                ret[0] = "Ottawa";
                ret[1] = "Senators";
                return ret;
            }
            else if (key == "LA")
            {
                ret[0] = "Los Angeles";
                ret[1] = "Kings";
                return ret;
            }
            else if (key == "ANA")
            {
                ret[0] = "Anaheim";
                ret[1] = "Ducks";
                return ret;
            }
            else if (key == "PHI")
            {
                ret[0] = "Philadelphia";
                ret[1] = "Flyers";
                return ret;
            }
            else if (key == "CBJ")
            {
                ret[0] = "Columbus";
                ret[1] = "Blue Jackets";
                return ret;
            }
            else if (key == "BOS")
            {
                ret[0] = "Boston";
                ret[1] = "Bruins";
                return ret;
            }
            else if (key == "BUF")
            {
                ret[0] = "Buffalo";
                ret[1] = "Sabres";
                return ret;
            }
            else if (key == "ARI")
            {
                ret[0] = "Arizona";
                ret[1] = "Coyotes";
                return ret;
            }
            else if (key == "DAL")
            {
                ret[0] = "Dallas";
                ret[1] = "Stars";
                return ret;
            }
            else if (key == "CGY")
            {
                ret[0] = "Calgary";
                ret[1] = "Flames";
                return ret;
            }
            else if (key == "SJ")
            {
                ret[0] = "San Jose";
                ret[1] = "Sharks";
                return ret;
            }
            else if (key == "TOR")
            {
                ret[0] = "Toronto";
                ret[1] = "Maple Leafs";
                return ret;
            }
            else if (key == "WPG")
            {
                ret[0] = "Winnipeg";
                ret[1] = "Jets";
                return ret;
            }
            else if (key == "VEG")
            {
                ret[0] = "Las Vegas";
                ret[1] = "Golden Knights";
                return ret;
            }
            else if (key == "STL")
            {
                ret[0] = "St. Louis";
                ret[1] = "Blues";
                return ret;
            }
            else if (key == "WAS")
            {
                ret[0] = "Washington";
                ret[1] = "Capitals";
                return ret;
            }
            else if (key == "NJ")
            {
                ret[0] = "New Jersey";
                ret[1] = "Devils";
                return ret;
            }
            else if (key == "SEA")
            {
                ret[0] = "Seattle";
                ret[1] = "Kraken";
                return ret;
            }
            else if (key == "NAS")
            {
                ret[0] = "Nashville";
                ret[1] = "Predators";
                return ret;
            }
            else
            {
                ret[0] = "";
                ret[1] = "";
                return ret;
            }
        }
    }
}
