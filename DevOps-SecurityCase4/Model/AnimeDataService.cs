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

        public List<Anime> GetHighscore()
        {
            string sql = "Select * from Anime order by Turns";
            return (List<Anime>)db.Query<Anime>(sql);
        }

        public void UpdateHighscore(Anime anime)
        {
            string sql = "Update Anime set playerId = @playerId, turns = @turns where id = @id";
            db.Execute(sql, new
            {
                anime.PlayerId,
                anime.Turns,
                anime.ID
            });
        }

        public void InsertHighscore(Anime anime)
        {
            string sql = "Insert into Anime (playerId, turns) values (@playerId, @turns)";
            db.Execute(sql, new
            {
                anime.PlayerId,
                anime.Turns
            });
        }


        public void DeleteHighscore(Anime anime)
        {
            string sql = "Delete Anime where id = @id";
            db.Execute(sql, new { anime.ID });
        }

    }
}
