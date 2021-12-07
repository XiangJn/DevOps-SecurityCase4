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
            UpdateCommand = new BaseCommand(UpdateAnime);
            DeleteCommand = new BaseCommand(DeleteAnime);
        }

        public ICommand DeleteCommand { get; set; }
        public ICommand UpdateCommand { get; set; }
   



        private void ReadAnime()
        {
            //instantiëren dataservice
            AnimeDataService animeDS =
               new AnimeDataService();

            Anime = new ObservableCollection<Anime>(animeDS.GetAnime());
        }

        public void UpdateAnime()
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
