using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsNHL.Model
{
    public class TeamInfo
    {
        private int _points;
        private String _key;
        private String _fullName;
        private String _logoPath;
        private int _matchCount;

        public TeamInfo(int points, String fullName, String logoPath)
        {
            _points = points;
            _fullName = fullName;
            _logoPath = logoPath;
        }

        public TeamInfo()
        {

        }

        public TeamInfo(String key)
        {
            _key = key;
        }

        public String Key
        {
            get { return _key; }
            set { _key = value; }
        }

        public int MatchCount
        {
            get { return _matchCount; }
            set { _matchCount = value; }
        }

        public int Points
        {
            get { return _points; }
            set { _points = value; }
        }

        public String FullName
        {
            get { return _fullName; }
            set { _fullName = value; }
        }

        public String LogoPath
        {
            get { return _logoPath; }
            set { _logoPath = value; }
        }
    }
}
