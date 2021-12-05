using System.Data.SqlClient;
using System.Configuration;
using System.Data;
using Dapper;
using System.Collections.Generic;

namespace DevOps_SecurityCase4.Model
{
    class AnimeDataService
    {
        private static string connectionString =
                ConfigurationManager.ConnectionStrings["azure"].ConnectionString;
        private static IDbConnection db = new SqlConnection(connectionString);

        public List<Anime> GetAnime()
        {
            string sql = "Select * from Anime order by Title";
            return (List<Anime>)db.Query<Anime>(sql);
        }

        public void UpdateAnime(Anime anime)
        {
            string sql = "Update Anime set title = @title, status = @status where id = @id";
            db.Execute(sql, new
            {
                anime.Title,
                anime.Status,
                anime.ID
            });
        }

        public void InsertAnime(Anime anime)
        {
            string sql = "Insert into Anime (title, status) values (@title, @status)";
            db.Execute(sql, new
            {
                anime.Title,
                anime.Status
            });
        }


        public void DeleteAnime(Anime anime)
        {
            string sql = "Delete Anime where id = @id";
            db.Execute(sql, new { anime.ID });
        }

    }
}
