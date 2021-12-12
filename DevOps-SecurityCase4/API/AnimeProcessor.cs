using DevOps_SecurityCase4.Model;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace DevOps_SecurityCase4.API
{
    class AnimeProcessor
    {
        public static async Task<AnimeResults> LoadAnime(string animeName)
        {
            string url = $"https://api.jikan.moe/v3/search/anime?q={animeName}";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    AnimeResults results = await response.Content.ReadAsAsync<AnimeResults>();
                  
                    return results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
