using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsNHL.Model
{
    public class Match
    {
        private TeamInfo _homeTeam;
        private TeamInfo _awayTeam;
        private int _awayScore;
        private int _homeScore;
        private String _date;

        public Match(TeamInfo homeTeam, TeamInfo awayTeam, int homeScore, int awayScore, String date)
        {
            _homeTeam = homeTeam;
            _awayTeam = awayTeam;
            _homeScore = homeScore;
            _awayScore = awayScore;
            _date = date;
        }

        public Match()
        {

        }

        public TeamInfo HomeTeam
        {
            get { return _homeTeam; }
            set { _homeTeam = value; }
        }

        public TeamInfo AwayTeam
        {
            get { return _awayTeam; }
            set { _awayTeam = value; }
        }

        public int HomeScore
        {
            get { return _homeScore; }
            set { _homeScore = value; }
        }

        public int AwayScore
        {
            get { return _awayScore; }
            set { _awayScore = value; }
        }

        public String Date
        {
            get { return _date; }
            set { _date = value; }
        }
    }
}
