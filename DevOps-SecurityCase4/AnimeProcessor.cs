using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using DevOps_SecurityCase4.Model;

namespace DevOps_SecurityCase4
{
    class AnimeProcessor
    {
        public static async Task<Anime> LoadAnime(string animeName)
        {
            //string url = "https://api.jikan.moe/v3/search/anime?q= { animeName }";
            string url = "https://api.jikan.moe/v3/search/anime?q=fairy%20tail";

            using (HttpResponseMessage response = await ApiHelper.ApiClient.GetAsync(url))
            {
                if (response.IsSuccessStatusCode)
                {
                    AnimeResult result = await response.Content.ReadAsAsync<AnimeResult>();

                    return result.Results;
                }
                else
                {
                    throw new Exception(response.ReasonPhrase);
                }
            }
        }
    }
}
