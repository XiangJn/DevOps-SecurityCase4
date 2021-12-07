using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DevOps_SecurityCase4.Model;
using System.Collections.ObjectModel;
using System.Windows.Input;
using System.Diagnostics;

namespace DevOps_SecurityCase4.ViewModel
{
    class AddAnimeViewModel : BaseViewModel
    {
        public AddAnimeViewModel()
        {
            ConnectCommands();
            //SearchAnime("tr");
        }

        private ObservableCollection<Anime> anime;
        public ObservableCollection<Anime> Anime
        {
            get
            {
                return anime;
            }

            set
            {
                anime = value;
                NotifyPropertyChanged();
            }
        }

        private Anime currentAnime;
        public Anime CurrentAnime
        {
            get
            {
                if (currentAnime == null)
                {
                    currentAnime = new Anime();
                }
                return currentAnime;
            }

            set
            {
                currentAnime = value;
                NotifyPropertyChanged();
            }
        }

        //private async void SearchAnime(string animeName)
        //{
        //    Anime = await AnimeProcessor.LoadAnime(animeName);
        //    Trace.WriteLine(animeInfo);

        //}

        private void ConnectCommands()
        {
            AddCommand = new BaseCommand(AddAnime);
        }

        public ICommand AddCommand { get; set; }
        public void AddAnime()
        {
            AnimeDataService animeDS =
                new AnimeDataService();
            animeDS.InsertAnime(CurrentAnime);    
        }

    }
}
