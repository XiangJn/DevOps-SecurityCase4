using System.Collections.ObjectModel;
using DevOps_SecurityCase4.Model;
using System.Windows.Input;

namespace DevOps_SecurityCase4.ViewModel
{
    class MyAnimeViewModel : BaseViewModel
    {
        public MyAnimeViewModel()
        {
            ReadAnime();
            ConnectCommands();
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


        private void ConnectCommands()
        {
            ChangeCommand = new BaseCommand(ChangeAnime);
            DeleteCommand = new BaseCommand(DeleteAnime);
            AddCommand = new BaseCommand(AddAnime);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand ChangeCommand { get; set; }
        public ICommand AddCommand { get; set; }



        private void ReadAnime()
        {
            //instantiëren dataservice
            AnimeDataService animeDS =
               new AnimeDataService();

            Anime = new ObservableCollection<Anime>(animeDS.GetAnime());
        }

        public void ChangeAnime()
        {
            if (CurrentAnime != null)
            {
                AnimeDataService animeDS =
                new AnimeDataService();
                animeDS.UpdateAnime(CurrentAnime);

                //Refresh
                ReadAnime();
            }
        }


        public void AddAnime()
        {
            AnimeDataService animeDS =
                new AnimeDataService();
            animeDS.InsertAnime(CurrentAnime);

            //Refresh
            ReadAnime();
        }



        public void DeleteAnime()
        {
            if (CurrentAnime != null)
            {
                AnimeDataService animeDS =
                    new AnimeDataService();
                animeDS.DeleteAnime(CurrentAnime);

                //Refresh
                ReadAnime();
            }
        }

    }
}
