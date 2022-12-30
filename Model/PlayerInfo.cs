using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsNHL.Model
{
    public class PlayerInfo
    {
        private String _name;
        private String _position;
        private int _age;

        public PlayerInfo(String name, String position, int age)
        {
            _name = name;
            _position = position;
            _age = age;
        }

        public PlayerInfo()
        {

        }

        public String Name
        {
            get { return _name; }
            set { _name = value; }
        }

        public String Position
        {
            get { return _position; }
            set { _position = value; }
        }

        public int Age
        {
            get { return _age; }
            set { _age = value; }
        }
    }
}
