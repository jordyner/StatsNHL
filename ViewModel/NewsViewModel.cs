using StatsNHL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Documents;
using FantasyData.Api.Client.Model.NHL;
using FantasyData.Api.Client;

namespace StatsNHL.ViewModel
{
    class NewsViewModel : MainViewModel
    {
        private List<NewsDetail> _news;

        public NewsViewModel()
        {
            _news = new List<NewsDetail>();
            int counter = 0;

            List<int> randoms = prepare_random_numbers(GetNews().Count);
            foreach (var news in GetNews())
            {
                if(randoms.Contains(counter))
                {
                    _news.Add(new NewsDetail()
                    {
                        Title = news.Title,
                        Content = news.Content,
                        Image = @"\Images\News\" + news.Team + ".jpg",
                        SecondImage = @"\Images\News\" + news.Team + "2.jpg"
                    });

                    randoms.Remove(counter);
                }
                counter++;

                if(randoms.Count == 0)
                {
                    break;
                }
            }
        }

        private List<int> prepare_random_numbers(int range)
        {
            List<int> random = new List<int>();
            Random rnd = new Random();

            int random_value;
            int counter = 0;
            while (true)
            {
                random_value = rnd.Next(0, range);
                if (!random.Contains(random_value) )
                {

                    random.Add(random_value);
                    counter++;

                    if(counter == 4)
                    {
                        break;
                    }
                }
            }

            return random;
        }

            public List<NewsDetail> News { get { return _news; } set { _news = value; OnPropertyChanged(nameof(SelectedViewModel)); } }
    }
}
