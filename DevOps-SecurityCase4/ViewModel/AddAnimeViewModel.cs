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
using DevOps_SecurityCase4.API;
using Newtonsoft.Json.Linq;
using Newtonsoft.Json;

namespace DevOps_SecurityCase4.ViewModel
{
    class AddAnimeViewModel : BaseViewModel
    {
        public AddAnimeViewModel()
        {
            ConnectCommands();
        }

        

        private string searchTitle;
        public string SearchTitle
        {
            get
            {
                return searchTitle;
            }

            set
            {
                searchTitle = value;
                NotifyPropertyChanged();
            }
        }

        private AnimeResults animeTitle;
        public AnimeResults AnimeTitle
        {
            get
            {
                return animeTitle;
            }

            set
            {
                animeTitle = value;
                NotifyPropertyChanged();
            }
        }


        private Anime anime;
        public Anime Anime
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
            AddCommand = new BaseCommand(AddAnime);
            SearchCommand = new BaseCommand(SearchAnime);
        }

        public ICommand AddCommand { get; set; }
        public ICommand SearchCommand { get; set; }

        public void AddAnime()
        {
            AnimeDataService animeDS =
                new AnimeDataService();
            animeDS.InsertAnime(CurrentAnime);    
        }
        

        private async void SearchAnime()
        {
            
            //Anime = await AnimeProcessor.LoadAnime(SearchTitle);
            string url = $"https://api.jikan.moe/v3/search/anime?q={SearchTitle}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
         
                var title = await response.Content.ReadAsStringAsync();
                AnimeTitle = JsonConvert.DeserializeObject<AnimeResults>(title);
               
            }
            
        }
    }
}