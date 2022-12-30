using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StatsNHL.Model
{
    public class NewsDetail
    {
        private String _title;
        private String _image;
        private String _secondImage;
        private String _team;
        private String _content;

        public NewsDetail()
        {

        }

        public String Content
        {
            get { return _content; }
            set { _content = value; }
        }

        public String Title
        {
            get { return _title; }
            set { _title = value; }
        }

        public String Image
        {
            get { return _image; }
            set { _image = value; }
        }

        public String Team
        {
            get { return _team; }
            set { _team = value; }
        }

        public String SecondImage
        {
            get { return _secondImage; }
            set { _secondImage = value; }
        }
    }
}
